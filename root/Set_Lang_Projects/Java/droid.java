//we will make a class that create droids, this droids will get multiplied

public class Droid {
    String name;
    int batteryLevel;

    public Droid(String droidName) {
        name = droidName;
        this.batteryLevel = 100;
    }

    public String task() {
        return "Task Completed";
    }

    public String start() {
        return "Droid started";
    }

    public String toString() {
        return "My name is " + name + " and my battery level is " + batteryLevel + "%.";
    }

    public String performTask(String task) {
        this.batteryLevel -= 10;
        return name + " is performing task: " + task;
    }

    public void energyReport() {
        System.out.println(name + " battery level is " + batteryLevel + "%.");
    }

    public void energyTransfer(Droid otherDroid, int transferAmount) {
        if (this.batteryLevel >= transferAmount) {
            this.batteryLevel -= transferAmount;
            otherDroid.batteryLevel += transferAmount;
            System.out.println(this.name + " transferred " + transferAmount + "% energy to " + otherDroid.name + ".");
        } else {
            System.out.println(this.name + " does not have enough energy to transfer.");
        }
    }

    public static void main(String[] args) {
        // Create two instances of Droid
        Droid droid1 = new Droid("Codey");
        Droid droid2 = new Droid("Robo");

        // Display initial states
        System.out.println(droid1);
        System.out.println(droid2);

        // Perform tasks with droid1
        System.out.println(droid1.performTask("Read"));
        droid1.energyReport();

        System.out.println(droid1.performTask("Listen to Music"));
        droid1.energyReport();

        // Perform a task with droid2
        System.out.println(droid2.performTask("Clean"));
        droid2.energyReport();

        // Energy transfer from droid1 to droid2
        droid1.energyTransfer(droid2, 30);

        // Display battery levels after energy transfer
        droid1.energyReport();
        droid2.energyReport();

        // Another energy transfer, exceeding droid1's energy
        droid1.energyTransfer(droid2, 80);

        // Final states
        System.out.println(droid1);
        System.out.println(droid2);
    }
}
