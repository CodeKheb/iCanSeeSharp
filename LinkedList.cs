class LinkedList(int v, LinkedList? n)
{
    // ? operator to allow null initially
    public static LinkedList? firstNode = null;
    public static LinkedList? lastNode = null;
    public LinkedList? next = n;
    public int value = v;
    static void Main() {
        Console.Write("Amount of nodes: ");
        int numnodes = int.Parse(Console.ReadLine() ?? "");

        for (int i = 0; i < numnodes; i++) {
            Console.Write($"Value at {i}: ");
            int num = int.Parse(Console.ReadLine() ?? "");
            LinkedList n = new(num, null);

            if (lastNode != null) {
                lastNode.next = n;
                lastNode = n;
            } else {
                firstNode = n;
                lastNode = n;
            }
        }


        for (LinkedList? ptr = firstNode; ptr != null; ptr = ptr.next) {
            Console.Write(" " + ptr.value);
        }

        LinkedList reversedLinked = Reverse(firstNode);

        Console.WriteLine("\nReversed: ");
        for (LinkedList? ptr = reversedLinked; ptr != null; ptr = ptr.next) {
            Console.Write(" " + ptr.value);
        }

        LinkedList sortedLinked = Sort(reversedLinked);
        Console.WriteLine("\nSorted: ");
        for (LinkedList? ptr = sortedLinked; ptr != null; ptr = ptr.next) {
            Console.Write(" " + ptr.value);
        }
    }

    static LinkedList Reverse(LinkedList? head) {
        LinkedList? ptr = head;
        LinkedList? prev = null;

            while (ptr != null) {
                head = ptr.next;
                ptr.next = prev;
                prev = ptr;
                ptr = head;
            }

            if (prev == null) {
                throw new ArgumentException();
            }

            return prev;
    }

    static LinkedList Sort(LinkedList? head) {
        LinkedList? curr = head;
        LinkedList? sort = new(0, null);

        while (curr != null) {
            LinkedList? nextNode = curr.next;
            LinkedList? ptr = sort;

            while (ptr?.next != null && ptr.next.value < curr.value) {
                ptr = ptr.next;
            }

            curr.next = ptr?.next;
            ptr?.next = curr;

            curr = nextNode;
        }

        if (sort.next == null) {
            throw new ArgumentException();
        }

        return sort.next;
    }
}
