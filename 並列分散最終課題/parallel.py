from joblib import Parallel, delayed
from time import time
import cv2
import numpy as np

def proc(n):
    img = cv2.imread("target/cat.{}.jpg".format(n), 1)
    img = cv2.resize(img,(300,300))
    split = 3

    for s in range(0,300,split):
        for j in range(0,300,split):
            img2 = img[s:s+split,j:j+split]
            img2 = cv2.flip(img2,1)
            img[s:s+split,j:j+split] = img2
    return cv2.imwrite("out/output{}.jpg".format(n), img)


# 処理時間計測開始
start = time()

# 時間がかかる処理(並列処理)
sub = Parallel(n_jobs=2)( [delayed(proc)(i) for i in range(4000)] )
total = sum(sub)

# 処理時間を表示
print(total)
print('並列処理', (time() - start), "秒")

start2 = time()
single = Parallel(n_jobs=1)( [delayed(proc)(i) for i in range(4000)] )
print('単純実装', (time() - start2), "秒")
