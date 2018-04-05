# Contributing to Iyzipay Dotnet Client

[iyzipay-dotnet](https://github.com/armutcom/iyzipay-dotnet-client) is developed and maintained by [Armut.com](https://armut.com/) members.

All kind of pull requests even for things like typos, documentation, test cases, etc are always welcome. By submitting a pull request for this project, you agree to license your
contribution under the MIT license to this project.

## Getting Started

-   Make sure you have a [GitHub account](https://github.com/signup/free)
-   Submit a ticket for your issue, assuming one does not already exist.
    -   Clearly describe the issue including steps to reproduce the bug.
-   Fork the repository on GitHub

## Pull requests

Good pull requests, patches, improvements and new features are a fantastic
help. They should remain focused in scope and avoid containing unrelated
commits.

Adhering to the following process is the best way to get your work
included in the project:

1. [Fork](http://help.github.com/fork-a-repo/) the project, clone your fork,
   and configure the remotes:

   ```bash
   # Clone your fork of the repo into the current directory
   git clone https://github.com/armutcom/iyzipay-dotnet-client.git
   # Navigate to the newly cloned directory
   cd <folder-name>
   # Assign the original repo to a remote called "upstream"
   git remote add upstream https://github.com/armutcom/iyzipay-dotnet-client.git
   ```

2. If you cloned a while ago, get the latest changes from upstream:

   ```bash
   git checkout master
   git pull upstream master
   ```

3. Create a new topic branch (off the main project development branch) to
   contain your feature, change, or fix:

   ```bash
   git checkout -b <topic-branch-name>
   ```

4. Commit your changes in logical chunks. Use Git's
   [interactive rebase](https://help.github.com/articles/interactive-rebase)
   feature to tidy up your commits before making them public.

5. Locally merge (or rebase) the upstream development branch into your topic branch:

   ```bash
   git pull [--rebase] upstream master
   ```

6. Push your topic branch up to your fork:

   ```bash
   git push origin <topic-branch-name>
   ```

7. [Open a Pull Request](https://help.github.com/articles/using-pull-requests/)
    with a clear title and description against the `master` branch.
