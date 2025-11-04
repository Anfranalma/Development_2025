triangle_str = """\
3
7 4
2 4 6
8 5 9 3"""

triangle = [list(map(int, row.split())) for row in triangle_str.splitlines()]

for row in range(len(triangle) - 2, -1, -1):
    for col in range(len(triangle[row])):
        triangle[row][col] += max(triangle[row + 1][col], triangle[row + 1][col+1])

print(triangle[0][0])