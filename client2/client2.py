# -*- coding: utf-8 -*-
import paho.mqtt.client as paho
import time
import os

input("Press ENTER to start...")


clear = lambda: os.system('cls')
client = paho.Client()

reciver = 0
send = 0

def on_message(client, userdata, msg):  
    global reciver
    reciver = time.time()

    print(f"recebido:{str(msg.payload)}");
    print(f"Tempo:{reciver-send}");
    print("------------------------");
    clear()
    print("digite a message:")
    
def on_connect(client, userdata, flags, rc):
    client.subscribe("home/chat1")

client.connect('localhost')
client.on_connect = on_connect
client.on_message = on_message

client.loop_start()

while True:
    msg = input("digite a message:")
    send = time.time()
    msg_info = client.publish("home/chat1",msg,qos=2)