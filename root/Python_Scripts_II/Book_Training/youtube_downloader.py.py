import yt_dlp as ydt

url = input("Enter video url:")
if 'shorts/' in url:
    new_url = url.replace('shorts/','watch?v=')
   
else:
    new_url = url
 


ydl_opts = {}

with ydt.YoutubeDL(ydl_opts) as ydl:
    ydl.download([new_url])

print("Video downloaded successfully.")

