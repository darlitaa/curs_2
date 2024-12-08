#include <iostream>
#include <queue>
#include <stack>
using namespace std;
const int n = 10;
bool* visited = new bool[n];

int graph[n][n] = {
	{0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
    {1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
    {1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
    {0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
    {0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
    {0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
};

void BFS(int start){
    bool visited[n] = { false };
    queue<int> place;
    place.push(start);
    visited[start] = true;
    
    while (!place.empty()) {
        int view_cell = place.front();  
        cout << view_cell + 1 << " ";
        place.pop(); 

        for (int i = 0; i < n; i++) {
            if (graph[view_cell][i] != 0 && !visited[i]) {
                place.push(i);
                visited[i] = true; 
            }
        }
    }
}

void DFS(int start) {
    stack<int> place;
    place.push(start); 

    while (!place.empty()) {
        int current = place.top(); 
        place.pop();

        if (!visited[current]) { 
            cout << current + 1 << " ";
            visited[current] = true;
        }
        for (int i = n - 1; i >= 0; i--) {
            if (graph[current][i] != 0 && !visited[i]) {
                place.push(i);
            }
        }
    }
}

int main() {
    setlocale(LC_ALL, "Rus");

    cout << "список ребер:\n";
    int arr_1[11] = {1,1,2,2,3,4,4,5,6,7,9};
    int arr_2[11] = {2,5,7,8,8,6,9,6,9,8,10};
    for (int i = 0; i < 11; i++) {
        cout << "{" << arr_1[i] << ", " << arr_2[i] << "},  ";
        cout << "{" << arr_2[i] << ", " << arr_1[i] << "}\n";
    }

    cout << "\nматрица смежности:\n";
    for (int i = 0; i < n; i++) {
        visited[i] = false;
        for (int j = 0; j < n; j++) {
            cout << graph[i][j] << " ";
        }
        cout << "\n";
    }

    cout << "\nсписок смежности:\n";
    int arrRibs[n][3] = {
        {2,5,},
        {1,7,8},
        {8},
        {6,9},
        {1,6},
        {4,5,9},
        {2,8},
        {2,3,7},
        {4,6,10},
        {9},
    };
    for (int i = 0; i < n; i++) {
        cout << i + 1 << " -> {";
        for (int j = 0; j < 3; j++) {
            if (arrRibs[i][j] == 0)
                break;
            cout << arrRibs[i][j] << " ";
        }
        cout << "}\n";
    }

    int start_1;
    cout << "\n\nПоиск в ширину\n";
    cout << "Введите начальную вершину: "; cin >> start_1;
    cout << "Посещенные вершины: ";
    BFS(start_1 - 1);

    int start_2;
    cout << "\n\nПоиск в глубину\n";
    cout << "Введите начальную вершину: "; cin >> start_2;
    cout << "Посещенные вершины: ";
    DFS(start_2 - 1);
    cout << "\n";

    delete[] visited;
}