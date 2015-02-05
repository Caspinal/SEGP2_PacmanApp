/*
 Run code in IDE 

 *Main Changes*

 - Replaced case 0 with "p" to stop printing "w" on grid
 - "p" also is therefore printed twice as much 
 - Code for creating wall cubes at a random position and a random size


 Please remember the code (for creating wall cubes) is quite messy and has some 
 problems so please don't be hesitant to disgard this addition


 *Also removed previous comments to show the changes more clearly*

 sorry again for the messy/confusing code

 */
import java.io.BufferedWriter;
import java.util.Random;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class ProceduralGenerationTwo {

    public static void main(String[] args) {
        tester(generateArray());

    }

    public static String[][] generateArray() {

        String[][] aryMap = new String[100][100];

        for (int x = 0; x < aryMap.length; x++) {
            for (int y = 0; y < aryMap.length; y++) {
                switch (randInt(0, 2)) {

                    case 0:
                        aryMap[x][y] = "p";  // Changed so it does not include "w" in grid, instead increases amount of "p"
                        break;
                    case 1:
                        aryMap[x][y] = "p";
                        break;
                    case 2:
                        aryMap[x][y] = "o";
                        break;
                    default:
                        aryMap[x][y] = "";
                        break;
                }
            }
        }

        for (int xx = 0; xx < aryMap.length; xx++) {

            aryMap[xx][0] = "w";
            aryMap[xx][aryMap.length - 1] = "w";
            aryMap[0][xx] = "w";
            aryMap[aryMap.length - 1][xx] = "w";
        }

        int randomNumForIteration = randInt(200, 250); // CHANGE THIS TO SEE HOW MANY BLOCKS YOU WOULD LIKE ON THE SCREEN 9999,9999  = max 
        int randomNumForX = 0; // used for random positioning of "w" across X (vertical)
        int randomNumForY = 0; // same as above... across Y (horizontal)
        int startingValX; // Initial random value
        int startingValY; // same as above
        int wall = 0; // TO CHANGE SIZE OF CUBE, HARD CODE THIS 

        for (int x = 1; x < randomNumForIteration; x++) { // loop for amount of blocks on the screen
            wall = randInt(1, 6); // comment this to change blocks to certain size from the wall var

            randomNumForX = randInt(5, 93);
            randomNumForY = randInt(5, 93);

            startingValX = randomNumForX;
            startingValY = randomNumForY;
            aryMap[randomNumForX][randomNumForY] = "w"; // places w at a random spot
            for (int i = 0; i < wall; i++) {   // loop for how wide the block is

                aryMap[randomNumForX][randomNumForY = randomNumForY + 1] = "w"; // draws one accross
                if (wall - 1 == i) {  // if used to remove the extra w on the first line of the block
                    aryMap[randomNumForX][randomNumForY] = "o"; // change the extra "w" to "o"
                }
                for (int k = 0; k < wall - 1; k++) { // loop for how deep the block is
                    aryMap[startingValX = startingValX + 1][startingValY] = "w"; // draws one down
                }
                startingValY = randomNumForY; // assigns it back to randomNumForY 
                // to help with next iteration of loop so
                // it starts one space ahead

                startingValX = randomNumForX;
            }
        }
        return aryMap;
    }

    public static int randInt(int min, int max) {
        Random rand = new Random();

        int randomNum = rand.nextInt((max - min) + 1) + min;

        return randomNum;
    }

    public static void tester(String[][] aryMap) {
        System.out.println("TESTER");

        try {
            File file = new File("filename.txt");

            // if file doesnt exists, then create it
            if (!file.exists()) {
                file.createNewFile();
                System.out.println("File created");
            }

            FileWriter fw = new FileWriter(file.getAbsoluteFile());
            BufferedWriter bw = new BufferedWriter(fw);

            String[] arrayTwo = new String[100];
            for (int x = 0; x < aryMap.length; x++) {
                System.out.println();
                bw.write("");
                for (int y = 0; y < aryMap.length; y++) {
                    bw.write(aryMap[x][y]);
                    System.out.print(aryMap[x][y]);
                }
                bw.write("\n");
                bw.newLine();
            }
            bw.close();
            System.out.println("Done");

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
