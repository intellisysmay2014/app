configs ={
  :git => {
    :provider => 'github',
    :user => 'intellisysmay2014',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
