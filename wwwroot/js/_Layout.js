
//Create an array where the message along with it's ID will be stored.
let message = [];
const i = 0;

// This fuction will enables us to add the message to the DOM
function addMessage(text) {
    //Object where message will be stored
    const chat = {
        text

    }

    message.push(chat);

    //Render message to the screen
    const list = document.querySelector('.msg-bottom');
    list.insertAdjacentHTML('beforebegin',
        `
            <div b-qeqqfkh6ta class="outgoing-chats">
                            <div b-qeqqfkh6ta class="outgoing-msg">
                                <div b-qeqqfkh6ta class="outgoing-chats-msg">
                                    <p b-qeqqfkh6ta class="multi-msg">
                                       ${chat.text}
                                    </p>
                                    <span>${new Date().toString() }</span>
                                </div>
                            </div>
                        </div>`

    );

    //const requestOptions = {
    //    method: 'POST',
    //    headers: {
    //        'Content-Type': 'application/json',
    //    },
    //    body: JSON.stringify(data),
    //};

    //const data = {
    //    InputMessage: chat.text
    //};
    //fetch(apiUrl, requestOptions, data);

        fetchdemo();

}






const apiUrl = 'https://api.example.com/data';

function fetchdemo() {

        addAIMessage('An attribute is a way to add additional metadata to a programming construct, such as a class, method, or property, in C#. It provides a means of associating additional data with the construct it decorates. Attributes appear within square brackets preceding the construct they decorate. They can be used to provide additional information or behavior to the construct at runtime or compile-time.');
        
}


//fetch(apiUrl, requestOptions, data)
//    .then(response => {
//        if (!response.ok) {
//            throw new Error('Network response was not ok');
//        }
//        return response.json();
//    })
//    .then(data => {
//        // Display data in an HTML element
//        addAIMessage(JSON.stringify(data, null, 2));
//    })
//    .catch(error => {
//        console.error('Error:', error);
//    });


function addAIMessage(text) {
    //Object where message will be stored
    const AIchat = {
        text

    }

    message.push(AIchat);

    //Render message to the screen
    const list = document.querySelector('.msg-bottom');
    list.insertAdjacentHTML('beforebegin',
        `
            <div b-qeqqfkh6ta class="received-chats">
                            <div b-qeqqfkh6ta class="received-msg">
                                <div b-qeqqfkh6ta class="received-msg-inbox">
                                    <p b-qeqqfkh6ta>
                                       ${AIchat.text}
                                    </p>
                                </div>
                            </div>
                        </div>`

    );

}

const form = document.querySelector('.input-group');
form.addEventListener('submit', event => {
    event.preventDefault();


    const input = document.querySelector('.form-control');


    const text = input.value.trim();

    if (text !== '') {
        addMessage(text);
        input.value = '';
        input.focus();

    }
});

///to be filled with Recived AI output
//form.addEventListener('', event => {
//    event.preventDefault();


//    const input = document.querySelector('.form-control');


//    const text = input.value.trim();

//    if (text !== '') {
//        addAIMessage(text);
//        input.value = '';
//        input.focus();

//    }
//});
