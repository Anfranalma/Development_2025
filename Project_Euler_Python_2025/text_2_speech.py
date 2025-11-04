# import sys

# try:
#     import pyttsx3
# except ImportError:
#     print('The pyttsx3 module is needed to be installed to run this')
#     print('program. on Windows, open a command promt and runL:')
#     print('pip install pyttsx3')
#     sys.exit()

# tts = pyttsx3.init()

# print('Text To Speech Talker, by myself')
# print()
# print('Enter the text to speak, or QUIT to quit')
# while True:
#     text = input('> ')
#     if text.upper() == 'QUIT':
#         print(('Thanks for playing!'))
#         sys.exit

#     tts.say(text)
#     tts.runAndWait()

# import pyttsx3

# tts = pyttsx3.init()
# voices = tts.getProperty('voices')

# # Try a different voice (Windows users can try 1 for female voice)
# tts.setProperty('voice', voices[1].id)  

# # Adjust speed
# tts.setProperty('rate', 150)  

# print('Enter text to speak, or QUIT to quit.')
# while True:
#     text = input('> ')
#     if text.upper() == 'QUIT':
#         print('Thanks for playing!')
#         break

#     tts.say(text)
#     tts.runAndWait()


from gtts import gTTS
import os

print('Enter text to speak, or QUIT to quit.')
while True:
    text = input('> ')
    if text.upper() == 'QUIT':
        print('Thanks for playing!')
        break

    tts = gTTS(text=text, lang='en')
    tts.save("speech.mp3")
    os.system("start speech.mp3")  # Works on Windows, use "afplay speech.mp3" for macOS

