/**
 * Changes in here include:
 *
 * Changed size of the grid from 100 by 100 to a random size from 20-30 so every
 * time the program is launched, a size between them numbers is chosen as the
 * size
 *
 * Reduced size of the ghost spawn considerably from 30 blocks by 30 blocks to 5
 * by 7 blocks
 *
 * The ghost spawn block now includes a calculation of where it is placed so
 * that it is in the centre however it may be at most one block off due to
 * truncation of integers such as 15 / 2.
 *
 * Also, other ghost letters are added inside of the ghost spawn block at
 * certain positions, two on the second line from top and two on the 3rd line
 * from top.
 *
 * Other changes include making methods to handle wall checking outside of inner
 * wall blocks and also the ghost spawn box. This reduces the wall of if
 * statements used in both scenarios
 *
 * Also, some of the code is merged together with others so that more can be
 * done in one iteration of the loops instead of using multiple loops separately
 * which makes the computer work more.
 * 
 * Carried out by Yahya and also with the help of Calumn with the ghost spawn box + James
 */
import java.io.BufferedWriter;
import java.util.Random;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class RG {

    public static void main(String[] args) {
        tester(generateArray());
    }

    public static String[][] generateArray() {

        int randomNumForX = 0, randomNumForY = 0;
        int randomNumForIteration = randInt(400, 400);

        int startingValX = 0, startingValY = 0;
        int wall = 0;
        int wallWidth = 0, wallHeight = 0;
        int randIntWidthOne = 5, randIntWidthTwo = 5;
        int randomNumForX_Width = 0;
        int randIntHeightOne = 5, randIntHeightTwo = 5;
        int randomNumForY_Height = 0;
        int yCopy = 0;
        String tester = "p";
        //int x = 0;

        int randomReduceO = 0;
        int arrayLength = randInt(20, 30);

        int coX = (arrayLength / 2) - 3; // coordinates for X
        int coY = (arrayLength / 2) - 2; // coordinates for Y
        int coStartX = coX; // stores initial value of coX
        int coStartY = coY;// stores initial value of coY
        int xx;
        int depth = 5;
        int width = 7;

        int randomLine = 0;
        int[] pelletPosition = new int[30];
        int arrayCounter = 0;
        int choosePelletPosition = 0;
        int indexChosen = 0;

        String[][] array = new String[arrayLength][arrayLength];

        for (int i = 0; i < randomNumForIteration; i++) {

            wallWidth = randInt(randIntWidthOne, randIntWidthTwo);
            wallHeight = randInt(randIntHeightOne, randIntHeightTwo);
            if (true) {
                randomNumForX_Width = (arrayLength - randIntWidthTwo) - 2;
                randomNumForY_Height = (arrayLength - randIntHeightTwo) - 2;
            }

            randomNumForX = randInt(2, randomNumForX_Width);
            randomNumForY = randInt(2, randomNumForY_Height);
            startingValX = randomNumForX;
            startingValY = randomNumForY;
            array[randomNumForY][randomNumForX] = "w";

            //if (yCopy != arrayLength) {
            while (yCopy != arrayLength - 1) {
                for (int y = 0; y < arrayLength; y++) {
                    yCopy = y;
                    randomReduceO = randInt(0, 100);
                    for (int x = 0; x < arrayLength; x++) {

                        array[0][y] = "w"; // top wall
                        array[arrayLength - 1][y] = "w"; //  bottom wall
                        array[y][arrayLength - 1] = "w"; // right wall
                        array[y][0] = "w";             // left wall

                        randomNumForIteration = randInt(1, 500);

                        switch (randInt(0, 1)) {
                            case 0:
                                if (array[y][x] == "w") {
                                    break;
                                } else {
                                    array[y][x] = "p";
                                    break;
                                }
                            case 1:
                                if (array[y][x] == "w") {
                                    break;
                                } else {
                                    if (randomReduceO <= 10) {
                                        array[y][x] = "o";
                                        break;
                                    } else {
                                        array[y][x] = "p";
                                        break;
                                    }
                                }
                            default:
                                System.out.println("Error, number out of bounds");
                                break;
                        }
                    }
                }
            }
            for (int y = 0; y < wallHeight; y++) { // changing wall var value effects height of the block
                //      System.out.println("y = " + y); // used for de bugging
                for (int x = 0; x < wallWidth; x++) { // changing wall effects how many across it prints
                    checkAroundWall(x, 0, randomNumForY - 1, randomNumForX - 1, array, tester);
                    checkAroundWall(y, wallHeight - 1, x, 0, randomNumForY, randomNumForX - 1, array, tester, randomNumForY + 1, randomNumForX - 1, "two");
                    checkAroundWall(y, wallHeight - 1, randomNumForY + 1, randomNumForX, array, tester);
                    checkAroundWall(x, wallWidth - 1, randomNumForY + 1, randomNumForX + 1, array, tester);
                    checkAroundWall(y, 0, x, wallWidth - 1, randomNumForY, randomNumForX + 1, array, tester, randomNumForY - 1, randomNumForX + 1, "two");
                    checkAroundWall(y, 0, randomNumForY - 1, randomNumForX, array, tester);
                    array[randomNumForY][randomNumForX] = "w"; // overwrites the first "w"
                    randomNumForX++; // jumps to the next space across
                }
                randomNumForX = startingValX; // assigns it back to the beginning position
                ++randomNumForY; // moves one down

            }
        }

        for (int i = 0; i < 1; i++) {
            array[coY][coX] = "w";

            for (int yy = 0; yy < depth; yy++) { // depth
                for (xx = 0; xx < width; xx++) { // width 

                    array[coY][coX] = "w"; // overwrites the "w"
                    if (xx == 0 && yy == 0) { // checks top left "w"
                        if (array[coY - 1][coX - 1].equals("w")) {
                            array[coY - 1][coX - 1] = tester;
                        }
                    }
                    checkAroundWall(xx, 0, yy, 0, coY - 1, coX - 1, array, tester, 0, 0, "one");  // works
                    checkAroundWall(xx, 0, coY, coX - 1, array, tester); // works
                    checkAroundWall(xx, 0, yy, depth - 1, coY + 1, coX - 1, array, tester, 0, 0, "one"); // works
                    checkAroundWall(yy, depth - 1, coY + 1, coX, array, tester); // works
                    checkAroundWall(xx, width - 1, yy, depth - 1, coY + 1, coX + 1, array, tester, 0, 0, "one"); // works
                    checkAroundWall(xx, width - 1, coY, coX + 1, array, tester); // works
                    checkAroundWall(xx, width - 1, yy, 0, coY - 1, coX + 1, array, tester, 0, 0, "one"); //works
                    checkAroundWall(yy, 0, coY - 1, coX, array, tester);

                    coX = coX + 1; // moves accorss one
                }
                coX = coStartX; // Start back to the left
                ++coY; // move one down
            }
            coY = coStartY; // assigns coY back to the start position so that it can be used in the 
            // the next for loop
        }

        coX++;
        coY++;
        coStartX++;

        boolean oneIteration = true;

        for (int y = 0; y < depth - 2; y++) {
            for (int x = 0; x < width - 2; x++) {

                if (oneIteration) {
                    array[coY + 1][coX + 2] = "n";
                    array[coY + 1][coX + 3] = "l";
                    array[coY + 2][coX + 2] = "k";
                    array[coY + 1][coX + 3] = "c";
                    oneIteration = false;
                }
                if (array[coY][coX].equals("w")) {
                    array[coY][coX] = "S";
                }
                coX++;
            }

            coX = coStartX;
            coY++;
        }

        while (true) {                                        // This is always true unless break
            randomLine = randInt(1, arrayLength - 2);         // Choose a random line from 1 to the length of the array-2, This
            // misses out the line at 0 which is a wall and the line at the end which is 
            // also a wall
            for (int i = 1; i < arrayLength - 1; i++) {         // Start a for loop iterating from the element after the first (one after 'w') 
                // to the last element -1 ( one before 'w')
                if (array[randomLine][i].equals("p")) {       // if the element in this position equals a 'p', 
                    pelletPosition[arrayCounter] = i;         // then store the position in the array pelletPosition
                    arrayCounter++;                           // iterate the counter to move up
                }
            }

            if (pelletPosition != null) {                                    // if the array is not empty
                choosePelletPosition = randInt(0, arrayCounter - 1);           // then choose a random position in the array
                indexChosen = pelletPosition[choosePelletPosition];         // assign variable to the position in the array of value
                array[randomLine][indexChosen] = "m";                       // assign the position in the array as 'm'
                //System.out.println("Chose line: " + randomLine);            // debug message
                //System.out.println("Chose position: " + pelletPosition[choosePelletPosition]); // debug message
                break;      // break the while loop
            }
        }

        return array;
    }

    public static void checkAroundWall(int letter, int comparingValue, int randomNumForY,
            int randomNumForX, String array[][], String tester) {

        if (letter == comparingValue) {
            if (array[randomNumForY][randomNumForX].equals("w")) {
                array[randomNumForY][randomNumForX] = tester;
            }
        }
    }

    public static void checkAroundWall(int letter, int comparingValue, int secondLetter,
            int secondCompareValue, int randomNumForY, int randomNumForX,
            String array[][], String tester, int randomNumForYTwo, int randomNumForXTwo, String oneOrTwo) {

        if (letter == comparingValue && secondLetter == secondCompareValue) {
            if (array[randomNumForY][randomNumForX].equals("w")) {
                array[randomNumForY][randomNumForX] = tester;
            }
            if (oneOrTwo.equals("two")) {
                if (array[randomNumForYTwo][randomNumForXTwo].equals("w")) {
                    array[randomNumForYTwo][randomNumForXTwo] = tester;
                }
            }
        }
    }

    public static int randInt(int min, int max) {
        Random rand = new Random();

        int randomNum = rand.nextInt((max - min) + 1) + min;

        return randomNum;
    }

    public static void tester(String[][] aryMap) {
        try {
            File file = new File("filename.txt");
            //File file = new File("C:/Users/y4hy4_000/Documents/UNITY/New Unity Project 1/TestingMap.txt");

            // if file doesnt exists, then create it
            if (!file.exists()) {
                file.createNewFile();
            }

            FileWriter fw = new FileWriter(file.getAbsoluteFile());
            BufferedWriter bw = new BufferedWriter(fw);

            String[] arrayTwo = new String[100];
            for (int x = 0; x < aryMap.length; x++) {
                bw.write("");

                for (int y = 0; y < aryMap.length; y++) {
                    bw.write(aryMap[x][y]);
                    System.out.print(aryMap[x][y]);
                }

                //bw.write("\n"); // Taking this out allows the reader in javascript to draw the thing properly
                System.out.println();
                bw.newLine();
            }
            bw.close();
            //System.out.println("\nDone"); // debugging

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
