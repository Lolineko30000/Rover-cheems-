import numpy as np
import matplotlib.pyplot as plt
from matplotlib import style
from mpl_toolkits import mplot3d
style.use('ggplot')

X = np.array([[15, 15, 15],
                [14.8, 15, 15],
                [15, 15, 14.9],
                [14.9, 15, 15],
                [15, 14.9, 15],
              #
              [10, 15, 15],
              [5, 15, 15],
              [8, 12, 15],
              [9, 14, 15],
              [9, 15, 15],
              #/////Obst - derecha /////////
              [15, 8, 10],
              [15, 15, 6],
              [15, 9,11],
              [15, 13, 6],
              [15, 15, 10],
              #//////Obst - frente////////
              [15, 8, 15],
              [15, 10, 15],
              [15, 7, 15],
              [15, 9, 15],
              [15, 13, 15]
              ])


class K_Means:
    def __init__(self, k=4, tol=0.001, max_iter=300):
        self.k = k
        self.tol = tol
        self.max_iter = max_iter

    def train(self,data):

        self.centroids = {}

        for i in range(self.k):
            self.centroids[i] = data[i]

        for i in range(self.max_iter):
            self.classifications = {}

            for i in range(self.k):
                self.classifications[i] = []

            for featureset in data:
                distances = [np.linalg.norm(featureset-self.centroids[centroid]) for centroid in self.centroids]
                classification = distances.index(min(distances))
                self.classifications[classification].append(featureset)

            prev_centroids = dict(self.centroids)

            for classification in self.classifications:
                self.centroids[classification] = np.average(self.classifications[classification],axis=0)

            optimized = True

            for c in self.centroids:
                original_centroid = prev_centroids[c]
                current_centroid = self.centroids[c]
                if np.sum((current_centroid-original_centroid)/original_centroid*100.0) > self.tol:
                    #print(np.sum((current_centroid-original_centroid)/original_centroid*100.0))
                    optimized = False

            if optimized:
                break

    def predict(self,data):
        distances = [np.linalg.norm(data-self.centroids[centroid]) for centroid in self.centroids]
        classification = distances.index(min(distances))
        print(classification)
        return classification

model = K_Means()
model.train(X)


fig = plt.figure(figsize = (10, 7))
ax = plt.axes(projection ="3d")
for centroid in model.centroids:
    ax.scatter3D(model.centroids[centroid][0], model.centroids[centroid][1], model.centroids[centroid][2], marker="o", color="k", s=150, linewidths=5)

for classification in model.classifications:
    colors = ["b", "r", "g", "orange", "indigo"]
    color = colors[classification]
    for featureset in model.classifications[classification]:
        ax.scatter3D(featureset[0], featureset[1], featureset[2], marker="x", color=color, s=150, linewidths=5)

plt.show()

x_new = np.array([[15, 15, 15],
              [8, 15, 15],
              [15, 5, 9],
              [15, 6, 15],
              [15, 15, 15],
              [15, 15, 15]
              ])

for i in x_new:
    c = model.predict(i)
    if c == 1:
        print("move to the right")
    elif c == 2:
        print("move to the left")
    elif c == 0:
        print("move backwards")
    else:
        print("move forward")
