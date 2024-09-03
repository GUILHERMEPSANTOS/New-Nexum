#!/bin/bash

CLUSTER_NAME="new-nexum-cluster"

if ! kind get clusters | grep "new-nexum-cluster"; then 
    kind create cluster --config ./cluster/kind.cluster.yaml
fi    

kubectl apply -f profile/profile.env.config.yml
kubectl apply -f profile/profile.deployment.yml
kubectl apply -f profile/profile.service.yml