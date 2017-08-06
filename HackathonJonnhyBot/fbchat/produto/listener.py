# -*- coding: UTF-8 -*-
from random import randint
from time import sleep
import time
from fbchat import log, Client

# Subclass fbchat.Client and override required methods
class Listener(Client):

    def onMessage(self, author_id, message, thread_id, thread_type, **kwargs):
        self.markAsDelivered(author_id, thread_id)

        sleep(randint(1,3))
        self.markAsRead(author_id)
        log.info("Message from {} in {} ({}): {}".format(author_id, thread_id, thread_type.name, message))

        user = self.fetchUserInfo(thread_id)
        log.info("EXTRA {}").format(thread_id)

        # users = client.fetchAllUsers()
        # # for user in users:
        # # 	print("users' IDs: \n{}".format(user.uid))
        # user = self.fetchUserInfo(thread_id,[thread_id])
        # # user = self.fetchUserInfo(users[0].uid)
        
        # #user = client.searchForUsers(users[0])

        # log.info("Mensagem recebida de {}\n-{}\nfoto {}\n na thread {} ({}): \n{}".format(author_id, user.name, user.photo, thread_id, thread_type.name, message))
        # #log.info("Mensagem recebida de {}\n-{}\nfoto {}\n na thread {} ({}): \n{}".format(user.id, user.name, user.photo, thread_id, thread_type.name, message))

        # If you're not the author, echo
        # if author_id != self.uid:
        #     self.sendMessage(message, thread_id=thread_id, thread_type=thread_type)
		

client = Listener("mariasantoss2017@hotmail.com", "mariasantoss1")

client.listen()




# users = client.searchForUsers('<name of user>')
# user = users[0]
# print("User's ID: {}".format(user.uid))
# print("User's name: {}".format(user.name))
# print("User's profile picture url: {}".format(user.photo))
# print("User's main url: {}".format(user.url))