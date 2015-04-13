/*
 Run code in IDE 

 *Main Changes*

 - Replaced previous code for generating a structure to the inner walls
 as it was hiding major flaws
 
 - Changed Y and X variables to represent the correct axis as x was 
 representing the Y axis (horizontal) and y was representing the X
 axis (vertical)

 - Added code which properly makes sure outside of inner walls is free from blockage
 and ensures a path throughout all the map 

 - changed variables so inner walls now generate up to one block away from the edge

 - added a wall enclosure for ghosts which is at the middle of the map (always at the same position at the moment)
   
 - Filled inside of the ghost enclosure wall with pellets so something can be moved inside of it

 - Added code to check if there is any "w" outside the ghost wall enclosure 
 and if there is, it replaces it wil a "p" (pellet)

 - Made the ratio for pellets ("P") higher than that off the special pellet("o")

 - Added code to give inner walls a random height and width. Also added code so that
 position of inner block is moved slightly if the block is too large as it may run out of 
 the array. 

 - Removed duplicate code



 * Please give it a run and report any problems :D *
 
 */
import java.io.BufferedWriter;
import java.util.Random;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class RG{

    public static void main(String[] args) {
        printer(generateArray());
    }

    public static String[][] generateArray() { // generates multi-dimentional array properly filled in

        String[][] aryMap = new String[100][100]; // Creates the multi-dimentional array with 10,000 spaces
        int random; // This var is used for making the probability of printing "o" less common

        /*
         This loop fills all spaces in the multi-dimentional array with either a "o" or "w"
         */
        for (int y = 0; y < aryMap.length; y++) { // This loop decides the depth 
            // of the array (how many lines down it prints to).
            // It is set to 100.
            for (int x = 0; x < aryMap.length; x++) { // This loop decides the width 
                // (how much letters it prints on each line).
                // It is also set to 100.
                random = randInt(0, 100); // This assigns a random value between 0-100 for the random variable
                // defined above 

                /*
                 This switch uses the randInt() method to choose the number 0 or 1.
                 When it chooses one of them, it jumps to 'case 0' or 'case 1' and
                 executes the code within it.
                 */
                switch (randInt(0, 1)) { // chooses either '0' or '1' (50% chance)

                    case 0: // if the number is 0, enter this case
                        aryMap[y][x] = "p";  // assigns the letter "p" to the position in the array.
                        // it does this by using the variables defined in the two for loops, 'y' and 'x'.
                        break; // finish this iteration of the loop and carry out the next iteration
                    case 1: // if numbe ris 1 enter this case
                        if (random <= 10) { // if the value given to the variable 'random'
                            // is less than 10 or equals 10, then execute 
                            // code within the if.
                            aryMap[y][x] = "o"; // print "o" to the specified index
                            break; // finish this iteration of the loop
                        }
                        aryMap[y][x] = "p"; // if this case was entered but the number was not
                        // less than or equal to the variable "p", then
                        // print "p" instead of "o"
                        break; // finish this iteration of the loop
                    default: // enters this case if none of the above cases mathch 
                        aryMap[y][x] = ""; // assigns the position to an empty String
                        break; // finish this iteration of the loop
                }
            }
        }

        /*
         This for loop below produces the walls around the muli-dimentional array.
         It uses one the indexes across the y and x axis to place a row of "w".
         Be aware that the first [][] '[]' in the multi-dimentional array travels down 
         the rows whilst the second '[]' traves across the line.
         */
        for (int xx = 0; xx < aryMap.length; xx++) {
            aryMap[xx][0] = "w"; // creates left wall in the array
            aryMap[xx][aryMap.length - 1] = "w"; // creates right wall 
            aryMap[0][xx] = "w"; // creates bottom wall
            aryMap[aryMap.length - 1][xx] = "w"; // creates top wall
        }

        int randomNumForIteration = randInt(500, 500); // this var decides how many blocks of 
        // inner walls are created, note this is not ra
        // 
        int randomNumForX = 0; // used for random positioning of "w" across X (vertical)
        int randomNumForY = 0; // same as above... across Y (horizontal)
        int startingValX; // Initial random value
        int startingValY; // same as above
        String tester = "p"; // changes what is around the inner wall
        int wallWidth;
        int wallHeight;

        // width of the cube
        int randIntWidthOne = 1; // from how wide the block can be
        int randIntWidthTwo = 15; // how wide the block can be

        int randomNumForX_Width; // used to calculate how much space is needed from the right
        // hand side of the array to avoid ArrayIndexOutOfBoundsException

        int randIntHeightOne = 1; // from how deep the block is 
        int randIntHeightTwo = 15; // how deep the block can be

        int randomNumForY_Height; // used to calculate how much space is needed from the bottom 
        // of the array to avoid ArrayIndexOutOfBoundsException


        /*
         This for loop which consists of three (including it self) is used to print the inner walls
         within the the outer wall surrounding the multi-dimentional array. Within the for loops are assignment
         statements and boolean conditions. 
       
         Assignment statements are used within the for loops so that variables are assigned new values
         with each iteration as the randInt() method generates different integers each time.
        
         If statements are used to check if there is anything blocking the outside of the inner blocks of wall.
         If there is a "w" surrounding it, then that is replaced with a "p". This is to ensure that 
         walls do not clump together and make large structures which block pac-man from navigating freely
        
         */
        for (int i = 1; i < randomNumForIteration; i++) { // loop for amount of blocks on the screen

            /*
             The reason why variables were used in place of hard coded numbers was so 
             a computation could be done so that the height and width of walls could 
             change the index in which the block is printed. This allows larger blocks of inner walls
             to be placed one letter away from the outer wall surrounding the multi-
             dimentional array therefore removing the ArrayOutOfBoundsException
             */
            wallWidth = randInt(randIntWidthOne, randIntWidthTwo); // sets value for wall width defined in var above   
            wallHeight = randInt(randIntHeightOne, randIntHeightTwo); // sets value for wall height defined in var above

            if (true) { // always true
                randomNumForX_Width = (aryMap.length - randIntWidthTwo) - 2; // calculates space needed from right side
                randomNumForY_Height = (aryMap.length - randIntHeightTwo) - 2; // calculates space needed from bottom
            }

            randomNumForX = randInt(2, randomNumForX_Width); // sets range of where the blocks can be printed
            // within the array on X axis
            randomNumForY = randInt(2, randomNumForY_Height); // within the array on Y axis

            startingValX = randomNumForX; // stores initial index used for placing on x axis
            startingValY = randomNumForY; // stores initial index used for placing on y axis


            /*
             This loop is used to produce one block of inner wall. 
             It does this by using one for loop to move to the next line with each iteration but 
             then uses a second for loop inside of the first for loop. 
             The second for loop prints 100 letters on one line.
            
             So the first for loop moves to the next line with each iteration 
             whilst the second for loop prints letters on the same line 100 times for each 
             iteration of the first for loop. The position at which the block starting printing 
             on the y axis is saved in a variable so that it can be iterated each time so it moves 
             on to the next line.
            
             If statements are used within the second for loop to check for letters surrounding 
             the block as it is being made. The if statements also check diagonally in each corner
             so that a path is always surrounding the block.
            
             Also note that the reason why 'y' is used in the first '[]' and 'x' in the 
             second '[]' consistently throughout the class is because here (not sure if it 
             is a java thing) the computer looks down the rows and then across. Therefore 
             writing it in this order helps display it in a realistic manner and in the way 
             it actually works.
             */
            for (int y = 0; y < wallHeight; y++) { // used for getting to the next line
                for (int x = 0; x < wallWidth; x++) { // used for printing letters on the same line
                    aryMap[randomNumForY][randomNumForX] = "w"; // places "w" at random position
                    if (y == 0 && x == 0) { // checks top left "w"
                        if (aryMap[randomNumForY - 1][randomNumForX - 1].equals("w")) { // diagonal top left
                            aryMap[randomNumForY - 1][randomNumForX - 1] = tester;
                        }
                    }

                    if (x == 0) { // checks "w" on left side
                        if (aryMap[randomNumForY][randomNumForX - 1].equals("w")) { // left
                            aryMap[randomNumForY][randomNumForX - 1] = tester;
                        }
                    }
                    if (y == wallHeight - 1 && x == 0) { // checks bottom left "w",
                        if (aryMap[randomNumForY + 1][randomNumForX - 1].equals("w")) { // diagonal bottom left
                            aryMap[randomNumForY + 1][randomNumForX - 1] = tester;
                        }
                    }

                    if (y == wallHeight - 1) { // checks bottom layer of "w" 
                        if (aryMap[randomNumForY + 1][randomNumForX].equals("w")) { // down
                            aryMap[randomNumForY + 1][randomNumForX] = tester;
                        }
                    }

                    if (y == wallHeight - 1 && x == wallWidth - 1) { // checks bottom right "w"
                        if (aryMap[randomNumForY + 1][randomNumForX + 1].equals("w")) { // diagonal bottom right
                            aryMap[randomNumForY + 1][randomNumForX + 1] = tester;
                        }
                    }

                    if (x == wallWidth - 1) { // checks "w" on right side of block
                        if (aryMap[randomNumForY][randomNumForX + 1].equals("w")) { // right
                            aryMap[randomNumForY][randomNumForX + 1] = tester;
                        }
                    }

                    if (y == 0 && x == wallWidth - 1) { // checks "w" in the top right corner
                        if (aryMap[randomNumForY - 1][randomNumForX + 1].equals("w")) { // diagonal top right
                            aryMap[randomNumForY - 1][randomNumForX + 1] = tester;
                        }
                    }

                    if (y == 0) { // checks top row of "w" , up
                        if (aryMap[randomNumForY - 1][randomNumForX].equals("w")) { // up
                            aryMap[randomNumForY - 1][randomNumForX] = tester;
                        }
                    }

                    ++randomNumForX; // jumps to the next space across

                }
                randomNumForX = startingValX; // assigns it back to the beginning position
                ++randomNumForY; // moves one down
            }
        }

        /*
         below are variables used to create the ghost spawn box
         coX and coY are variables used to choose the starting point of the ghost
         spawn box
         */
        int coX = 35; // coordinates for X, 
        int coY = 35; // coordinates for Y
        int coStartX = coX; // stores initial value of coX
        int coStartY = coY;// stores initial value of coY
        int depth = 30; // height of the ghost spawn structure 
        int width = 30; // width of the ghost spawn structure

        /*
         The for loop below is similar to the one used to create inner blocks of walls
         however one difference is that instead of creating multiple blocks of walls, it 
         creates one large one which is why the first for loop iterates only once. This could 
         also be written without the first for loop since it iterates only once however it is 
         included just in case multiple spawn points are required in the future.
        
         If statements are used to check outside of the large ghost spawn block to ensure
         that it is clear of walls.
         */
        for (int i = 0; i < 1; i++) { // used for changing how many blocks are printed

            for (int yy = 0; yy < depth; yy++) { // used for height, predefined above
                for (int xx = 0; xx < width; xx++) { // used for width, predefined above

                    aryMap[coY][coX] = "w"; // places "w" at certain position predifined above

                    if (xx == 0 && yy == 0) { // checks top left "w"
                        if (aryMap[coY - 1][coX - 1].equals("w")) { // diagonal top left
                            aryMap[coY - 1][coX - 1] = tester;
                        }
                    }
                    if (xx == 0) { // checks "w" on left side
                        if (aryMap[coY][coX - 1].equals("w")) { // left
                            aryMap[coY][coX - 1] = tester;
                        }
                    }

                    if (yy == depth - 1 && xx == 0) { // checks bottom left "w"
                        if (aryMap[coY + 1][coX - 1].equals("w")) { // diagonal bottom left
                            aryMap[coY + 1][coX - 1] = tester;
                        }
                    }

                    if (yy == depth - 1) { // checks "w" across bottom
                        if (aryMap[coY + 1][coX].equals("w")) { // down
                            aryMap[coY + 1][coX] = tester;
                        }
                    }

                    if (yy == depth - 1 && xx == width - 1) { // checks "w" in bottom right corner
                        if (aryMap[coY + 1][coX + 1].equals("w")) { // diagonal bottom right
                            aryMap[coY + 1][coX + 1] = tester;
                        }
                    }

                    if (xx == width - 1) {// checks "w" on right hand side
                        if (aryMap[coY][coX + 1].equals("w")) { // right
                            aryMap[coY][coX + 1] = tester;
                        }
                    }

                    if (yy == 0 && xx == width - 1) { // checks "w" on right hand side
                        if (aryMap[coY - 1][coX + 1].equals("w")) { // diagonal top right
                            aryMap[coY - 1][coX + 1] = tester;
                        }
                    }

                    if (yy == 0) { // checks top row of "w"
                        if (aryMap[coY - 1][coX].equals("w")) { // top
                            aryMap[coY - 1][coX] = tester;
                        }
                    }
                    coX = coX + 1; // moves across one
                }
                coX = coStartX; // Start back to the left
                ++coY; // move one down
            }
            coY = coStartY; // assigns coY back to the start position so that it can be used in the 
                            // the next for loop below
        }
        
        /*
        The loop below fills the inside of the ghost spawn block in pellets.
        To do this it has to move one space down and across so it does not overwrite 
        the whole block, rather it leaves a wall of "w" one letter thick around it

        This is why the variables used in the above for loop are incremented by one 
        so that they are able to move one space inside the spawn block.
        */
        ++coX; // one is added so it moves one place below the wall
        ++coY; // one is added so it moves one place to the right of the wall
        ++coStartX; // adds one so it can move to the right place on the next line

        for (int yyy = 0; yyy < depth - 2; yyy++) { // depth
            for (int xxx = 0; xxx < width - 2; xxx++) { // width
                aryMap[coY][coX] = "p"; // places "p" at specified index
                coX = coX + 1; // move one across the line to the right
            }
            coX = coStartX; // assign it back to the beginning of the line
            ++coY; // move one line down
        }

        /*
        The for loop below is used to search through the entier multi-dimentional 
        array and look for "p" and "o". When it finds one, it increments the counter 
        and prints it when the loop is finished
        
        yyy and xxx is defined as 1 and the condition is set as length-1 because
        this would include the outer walls which would create more work so we need 
        to start one space inside
        */
        int counterForP = 0; // counter for "p"
        int counterForO = 0; // counter for "o"
        for (int yyy = 1; yyy < aryMap.length-1; yyy++) { // height 
            for (int xxx = 1; xxx < aryMap.length-1; xxx++) { // width
                if (aryMap[yyy][xxx].equals("p")) {  // if "p" is found at this index
                    ++counterForP; // increase counter for "p"
                }
                if (aryMap[yyy][xxx].equals("o")) { // if "o" is found at this index
                    ++counterForO; // increase counter for "o"
                }
            }
        }
        System.out.println("P = " + counterForP); // prints it 
        System.out.println("O = " + counterForO); // prints it

        return aryMap; // returns the multi-dimentional array filled up
    }

    public static int randInt(int min, int max) { // method to generate random numbers between
                                                  // a certain range
        Random rand = new Random();

        int randomNum = rand.nextInt((max - min) + 1) + min;

        return randomNum;
    }

    public static void printer(String[][] aryMap) { // method that prints the letters
        System.out.println("TESTER"); 

        try { // try used to catch exception
            File file = new File("filename.txt"); // create a new file Object and set its classpath 
                                                  // and filename or just filename.
                                                  // if only filename is selected,
                                                  // then it is stored where the class is
                                                  // created

            // if file doesnt exists, then create it
            if (!file.exists()) {
                file.createNewFile(); // creates the file
                System.out.println("File created"); // will only do this once when 
                                                    // the program is run first only if
                                                    // no classpath has been mentioned
            }

            FileWriter fw = new FileWriter(file.getAbsoluteFile()); 
            BufferedWriter bw = new BufferedWriter(fw);

            String[] arrayTwo = new String[100]; // creates array of 100 spaces
            for (int x = 0; x < aryMap.length; x++) { // height
                System.out.println(); // jumps to next line
                bw.write(""); // writes the string 
                for (int y = 0; y < aryMap.length; y++) { // width
                    bw.write(aryMap[x][y]); // writes value in the index to the file
                    System.out.print(aryMap[x][y]);  // places values of array next to each other
                }
                bw.write("\n"); // writes the 'next line' in the file so a new line
                                // is represented correctly
                //bw.newLine();   // writes a line seperator
            }
            bw.close(); // close stream
            System.out.println("\nDone");

        } catch (IOException e) { // catches input or output erros  
            e.printStackTrace();
        }
    }
}
