using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null) return;

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                if (wordCount.ContainsKey(currentWord))
                {
                    wordCount[currentWord]++;
                }
                else
                {
                    wordCount.Add(currentWord, 1);
                }
            }

            string[] keys = new string[wordCount.Count];
            wordCount.Keys.CopyTo(keys, 0);

            int[] counts = new int[wordCount.Count];
            wordCount.Values.CopyTo(counts, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {counts[i]}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null) return;

            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (numberCount.ContainsKey(currentNumber))
                {
                    numberCount[currentNumber]++;
                }
                else
                {
                    numberCount.Add(currentNumber, 1);
                }
            }

            int[] keys = new int[numberCount.Count];
            numberCount.Keys.CopyTo(keys, 0);

            int[] counts = new int[numberCount.Count];
            numberCount.Values.CopyTo(counts, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"number: {keys[i]} count: {counts[i]}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            if (input == null)
            {
                input = "";
            }

            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            LinkedList<char> stack = new LinkedList<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (bracketPairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
                else if (bracketPairs.ContainsValue(c))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char lastOpen = stack.Last.Value;
                    if (bracketPairs[lastOpen] != c)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    stack.RemoveLast();
                }
            }

            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List != null ? as04List.GetLinkedList() : new LinkedList<int>();

            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List != null ? as05List.GetLinkedList() : new LinkedList<string>();

            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary != null ? as06FirstDictionary.GetDictionary() : new Dictionary<string, int>();
            Dictionary<string, int> dict2 = as06SecondDictionary != null ? as06SecondDictionary.GetDictionary() : new Dictionary<string, int>();

            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                if (mergedDictionary.ContainsKey(kvp.Key))
                {
                    mergedDictionary[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            foreach (KeyValuePair<string, int> kvp in mergedDictionary)
            {
                Debug.Log($"key: {kvp.Key}, value: {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List != null ? as07List.GetLinkedList() : new LinkedList<int>();

            if (list.Count <= 1)
            {
                foreach (int val in list)
                {
                    Debug.Log(val);
                }
                return;
            }

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
                }

                current = next;
            }

            foreach (int val in list)
            {
                Debug.Log(val);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;

            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> frequency = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency.Add(num, 1);
                }
            }

            int topNumber = numbers[0];
            int maxCount = frequency[topNumber];

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                int count = frequency[num];
                if (count > maxCount)
                {
                    maxCount = count;
                    topNumber = num;
                }
            }

            Debug.Log($"{topNumber} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory != null ? as09Inventory.GetDictionary() : new Dictionary<string, int>();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (!string.IsNullOrEmpty(itemName))
            {
                if (inventory.ContainsKey(itemName))
                {
                    inventory[itemName] += quantity;
                }
                else
                {
                    inventory.Add(itemName, quantity);
                }
            }

            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue != null ? as10EventQueue.GetLinkedList() : new LinkedList<GameEvent>();

            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {currentEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                string eventType = currentEvent.EventType != null ? currentEvent.EventType.ToLower() : "";
                switch (eventType)
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.Name}");
                        break;
                    case "powerup":
                    case "power-up":
                        Debug.Log($"Power-up event processed - {currentEvent.Name}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.Name}");
                        break;
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats != null ? as11PlayerStats.GetDictionary() : new Dictionary<string, int>();
            string statName = as11StatName;
            int value = as11Value;

            if (!string.IsNullOrEmpty(statName))
            {
                if (playerStats.ContainsKey(statName))
                {
                    playerStats[statName] += value;
                }
                else
                {
                    playerStats.Add(statName, value);
                }

                Debug.Log($"Updated {statName}: {playerStats[statName]}");
            }

            Debug.Log("Current player statistics:");
            foreach (KeyValuePair<string, int> kvp in playerStats)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion
    }
}
