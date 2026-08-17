class LinkedList {
    // ? operator to allow null initially
    public static LinkedList? firstNode = null;
    public static LinkedList? lastNode = null;
    public LinkedList? next;
    public int value;

    public LinkedList(int v, LinkedList? n) {
        value = v;
        next = n;
    }

    static void Main() {
        Console.Write("Amount of nodes: ");
        int numnodes = int.Parse(Console.ReadLine() ?? "");

        for (int i = 0; i < numnodes; i++) {
            Console.Write($"Value at {i}: ");
            int num = int.Parse(Console.ReadLine() ?? "");
            LinkedList n = new LinkedList(num, null);

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
    }
}
