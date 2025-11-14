import yt_dlp as ydt

url = input("Enter video URL: ")

# Fix YouTube Shorts URL format
if 'shorts/' in url:
    new_url = url.replace('shorts/', 'watch?v=')
else:
    new_url = url

# Set options to download best video and audio, and merge into MP4
ydl_opts = {
    'format': 'bv*+ba/best',  # bestvideo+bestaudio (bv+ba) fallback to best if not available
    'merge_output_format': '2.mp4',
    'postprocessors': [{
        'key': 'FFmpegVideoConvertor',
        'preferedformat': 'mp4',
    }],
    'outtmpl': '%(title)s.%(ext)s',  # Output filename = video title
}

with ydt.YoutubeDL(ydl_opts) as ydl:
    ydl.download([new_url])

print("Video downloaded successfully.")
