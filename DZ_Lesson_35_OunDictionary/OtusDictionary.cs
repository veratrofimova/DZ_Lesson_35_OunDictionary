namespace DZ_Lesson_35_OunDictionary
{
    public class OtusDictionary
    {
        int _counter = 0;

        private static int _sizeOfArray;
        public static int SizeOfArray
        {
            get => _sizeOfArray;
            set => _sizeOfArray = value;
        }
        int GetHash(int key) => key % SizeOfArray;

        KeyValuePair[] keyValuePair;
        public OtusDictionary()
        {
            keyValuePair = new KeyValuePair[SizeOfArray];
        }

        public string this[int index]
        {
            get {
                return Get(index);
            }
            set {
                Add(index, value);
            }
        }

        public void Add(int key, string value)
        {
            if (_counter == SizeOfArray)
            {
                //throw new OverflowException("Добавление невозможно. Словарь заполнен");
                keyValuePair = ReSize();
            }

            var hash = GetHash(key);

            while (keyValuePair[hash] != null)
            {
                if (keyValuePair[hash].Key == key) 
                    throw new ArgumentException("Ключ уже существует");
            }
            keyValuePair[hash] = new KeyValuePair() { Key = key, Value = value };

            _counter++;
        }
                
        public KeyValuePair[] ReSize()
        {
            var newKeyValuePair = SetSizeOfArray(SizeOfArray * 2);

            foreach (var pair in keyValuePair)
            {
                if (pair == null) 
                    continue;

                var hash = GetHash(pair.Key);

                if (newKeyValuePair[hash] != null) 
                    return ReSize();

                newKeyValuePair[hash] = pair;
            }

            return newKeyValuePair;
        }

         public string Get(int key)
         {
        var hash = GetHash(key);

             if (keyValuePair[hash] != null)
                 return keyValuePair[hash].Value;
             else
                 throw new ArgumentOutOfRangeException("Ключ не существует");
         }

        public KeyValuePair[] SetSizeOfArray(int count)
        {
            SizeOfArray = count;

            Array.Resize(ref keyValuePair, SizeOfArray);

            return new KeyValuePair[SizeOfArray];
        }
    }
}
