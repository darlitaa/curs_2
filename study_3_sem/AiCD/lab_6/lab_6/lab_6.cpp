#include <iostream>
#include <vector>
#include <list>
#include <map>
#include <string>
#include <Windows.h>
using namespace std;

struct Node {
    int number;
    string symbol = "";
    Node* left, * right;
};

Node* HuffmanAlgorithm(list<Node*>& nodes) {
    while (nodes.size() != 1) {
        nodes.sort([](Node* firstNode, Node* secondNode) -> bool { 
            return firstNode->number < secondNode->number; 
        });

        Node* left = nodes.front();
        nodes.pop_front();
        Node* right = nodes.front();
        nodes.pop_front();

        Node* parent = new Node;
        parent->left = left;
        parent->right = right;
        parent->symbol += left->symbol + right->symbol;
        parent->number = left->number + right->number;

        nodes.push_back(parent);
    }

    return nodes.front();
}

void BuildTable(Node* root, vector<bool>& code, map<char, vector<bool>>& matchingTable) {
    if (root->left != nullptr) {
        code.push_back(0);
        BuildTable(root->left, code, matchingTable);
    }

    if (root->right != nullptr) {
        code.push_back(1);
        BuildTable(root->right, code, matchingTable);
    }

    if (root->left == nullptr && root->right == nullptr) {
        matchingTable[root->symbol[0]] = code;
    }

    if (!code.empty()) {
        code.pop_back();
    }
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    map<char, int> counter;
    map<char, vector<bool>> matchingTable;
    list<Node*> nodes;
    vector<bool> code;
    string text;

    cout << "Введите строку:";
    getline(cin, text);
    int size = text.size();
    for (int i = 0; i < size; i++) {
        counter[text[i]]++;
    }

    cout << "\nЧастота символов:\n";
    for (auto it = counter.begin(); it != counter.end(); it++) {
        cout << '\'' << it->first << '\'' << " -> " << it->second << endl;
        Node* node = new Node;
        node->symbol += it->first;
        node->number = it->second;
        node->left = nullptr;
        node->right = nullptr;
        nodes.push_back(node);
    }
    cout << endl;

    Node* root = HuffmanAlgorithm(nodes);
    BuildTable(root, code, matchingTable);

    cout << "\nКоды Хаффмана:\n";
    for (const auto& itm : matchingTable) {
        cout << '\'' << itm.first << '\'' << " = ";
        int tempSize = itm.second.size();
        for (int i = 0; i < tempSize; i++) {
            cout << itm.second[i];
        }
        cout << endl;
    }

    cout << "\nЗакодированное сообщение:";
    for (int i = 0; i < size; i++) {
        const vector<bool>& temp = matchingTable.at(text[i]);
        int sizeTemp = temp.size();
        for (int j = 0; j < sizeTemp; j++) {
            cout << temp[j];
        }
    }
    cout << endl;
}