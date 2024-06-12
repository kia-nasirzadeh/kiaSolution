we want to make a console app to respond like this:
1-
⚡ node .
you should choose a name it is required field
you can read help:
Usage: say hello to someone

Positionals:
  name  who you want to say hello                                     [required]

Options:
  -h, --help     Show help                                             [boolean]
  -v, --version
  -b, --box      round with a box                                      [boolean]



2-
⚡ node . -h
Usage: say hello to someone

Positionals:
  name  who you want to say hello                                     [required]

Options:
  -h, --help     Show help                                             [boolean]
  -v, --version
  -b, --box      round with a box                                      [boolean]



3-
⚡ node . ali
hello ali



4-
⚡ node . ali -b
╭─────────────────────╮
│                     │
│                     │
│      hello ali      │
│                     │
│                     │
╰─────────────────────╯
5-
⚡ node . ali -asdkfjd
there is an unknown argument, we cant run app

5- install as a global package and performing same steps, with "hello" instead of "node ."
6- uninstall it again