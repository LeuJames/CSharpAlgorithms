# Matrix Search
# Mike digs image recognition and wants to create a JavaScript Imaging Library, just like PIL for Python. He is given 2 different two-dimensional arrays, containing integers between 0 and 65535. Each two-dimensional array represents a gray-scale image, where each integer value is a pixel. The second image might be found somewhere within the larger one. Return whether it is.
# Given array: [[12,34,45,56], and array:[[67,78],return true. [98,87,76,65],[43,32]]
# [56,67,78,89], [54,43,32,21]]

pic1 = [
    [12,34,45,56],
    [98,87,76,65],
    [56,67,78,89],
    [54,43,42,21]
]

pic2 = [
  [67,78],
  [43,42]
]


def matrixSearch (matrix1, matrix2):
  height1 = len(matrix1)
  width1 = len(matrix1[0])
  height2 = len(matrix2)
  width2 = len(matrix2[0])


  for i in range(height1-height2+1):
    for j in range(width1-width2+1):
      if matrix1[i][j] == matrix2[0][0]:
        allMatch = True

        for m in range (height2):
          for n in range(width2):
            if matrix1[i+m][j+n] != matrix2[m][n]:
              allMatch = False
        if allMatch:
          return True
  return False

print(matrixSearch(pic1, pic2))