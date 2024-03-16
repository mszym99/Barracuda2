//Create an array where the message along with it's ID will be stored.
let message = [];

// This fuction will enables us to add the message to the DOM
function addMessage(text) {
    //Object where message will be stored
    const chat = {
        text

    }

    message.push(chat);

    //Render message to the screen
    const list = document.querySelector('.msg-page');
    list.insertAdjacentHTML('beforebegin',
        `
            <div b-qeqqfkh6ta class="outgoing-chats">
                            <div b-qeqqfkh6ta class="outgoing-msg">
                                <div b-qeqqfkh6ta class="outgoing-chats-msg">
                                    <p b-qeqqfkh6ta class="multi-msg">
                                       ${chat.text}
                                    </p>
                                </div>
                            </div>
                        </div>`

    );

}

function addAIMessage(text) {
    //Object where message will be stored
    const AIchat = {
        text

    }

    message.push(AIchat);

    //Render message to the screen
    const list = document.querySelector('.msg-page');
    list.insertAdjacentHTML('beforebegin',
        `
            <div b-qeqqfkh6ta class="received-chats">
                            <div b-qeqqfkh6ta class="received-msg">
                                <div b-qeqqfkh6ta class="received-msg-inbox">
                                    <p>
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
