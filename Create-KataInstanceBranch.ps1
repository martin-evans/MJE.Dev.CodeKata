
<# Creates a new branch in master from which a kata may begin #>

git checkout master

$branch = (New-Guid).ToString() -split "-" | select -First 1

git branch $branch
git checkout $branch
git push --set-upstream origin $branch

"Run kata from branch $branch"
