# -*- coding: UTF-8 -*-

from fbchat import Client
from fbchat.models import *

client = Client('mariasantoss2017@hotmail.com', 'mariasantoss1')

print('Own id: {}'.format(client.uid))

client.sendMessage('-_-_-_-_-_-_-_', thread_id='100000754873542', thread_type=ThreadType.USER)

client.logout()
