        $changedFiles = git diff --name-only HEAD~2 HEAD

        foreach ($file in $changedFiles) {
            echo $file.Name
             Move-Item -Path $file -Destination ".\DB Script\"
        }