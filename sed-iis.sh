find  . -iname '*.log' | while read obj ; do
sed '/^#/d' --in-place "$obj"
done
