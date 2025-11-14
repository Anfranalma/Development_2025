import ctypes
import time
import math

user32  = ctypes.windll.user32

def implication():
    ctypes.windll.user32.SetCursorPos(x,y)


s_width = user32.GetSystemMetrics(0)
s_height = user32.GetSystemMetrics(1)

radius = 50
duration = 10
steps = 100
c_x, c_y, = user32.GetCursorPos()

start_time = time.time()
while time.time() - start_time < duration:
    for i in range(steps):
        angle=2*math.pi * i / steps
        x= int(c_x + radius * math.sin(angle))