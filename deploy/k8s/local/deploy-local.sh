kind create cluster --config ./cluster/kind.cluster.yaml

kubectl apply -f profile/profile.env.config.yml
kubectl apply -f profile/profile.deployment.yml
kubectl apply -f profile/profile.service.yml