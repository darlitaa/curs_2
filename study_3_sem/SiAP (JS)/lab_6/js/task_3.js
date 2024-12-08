let store = {
  state: { //1 уровень
    profilePage: { //2 уровень
      posts: [ //3 уровень
        {id: 1, message: 'Hi', likeCount: 12},
        {id: 2, message: 'By', likeCount: 1},
      ],
      newPostText: 'About me',
    },

    dialogsPage: {
      dialogs: [
        {id: 1, name: 'Valera'},
        {id: 2, name: 'Andrey'},
        {id: 3, name: 'Sasha'},
        {id: 4, name: 'Viktor'},
      ],
      messages: [
        {id: 1, message: 'hi'},
        {id: 2, message: 'hi hi'},
        {id: 3, message: 'hi hi hi'},
      ],
    },
    sidebar:[],
  },
}

let {state:{profilePage:{posts}, dialogsPage:{dialogs, messages},sidebar }} = store;

for(post of posts) {
  console.log(post.likeCount);
}

let filterdialogs = dialogs.filter(function(dialog) {
  return dialog.id % 2 == 0;
});
console.log(filterdialogs);

let newMessage = messages.map((message) => "Hello user");
console.log(newMessage);
