/*
Main changes from ProceduralGenerationFive

- Added code to create a diamond structure which also checks around its body
 for blockages and if so, it removes them. 

- Added a switch including the code to create blocks and diamonds so that it chooses 
  randomly which one to create (diamond or block) each iteration. 

*/



import java.io.BufferedWriter;
import java.util.Random;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class ProceduralGenerationSix {

    public static void main(String[] args) {
        printer(generateArray());
    }

    public static String[][] generateArray() { // creates the multi-dimentional array 

        String[][] aryMap = new String[100][100]; // creates the arra with 10,000 spaces
        int random; // variable used to reduce "p" 

        /*
        For loop used to print eiher "p" or "o" on the multi-dimentional array
        */
        for (int y = 0; y < aryMap.length; y++) { // loop to iterate vertically down the array

            for (int x = 0; x < aryMap.length; x++) { // loop to iterate across array 
                random = randInt(0, 200);  // INCREASE SECOND NUMBER FOR FEWER "o" ON SCREEN

                switch (randInt(0, 1)) { // chooses random number from 0 or 1

                    case 0: // if  0 is chosen...
                        aryMap[y][x] = "p"; // then print "p" on the array
                        break;
                    case 1: // if 1 is chosen...
                        if (random <= 10) { // this 'if' is used to further reduce the amount 
                                            // of "o" that are printed on the screen.
                            aryMap[y][x] = "o"; // If above conditions are true, then print "o" on the screen
                            break;
                        }
                        aryMap[y][x] = "p"; // if the above conditions are not true, then a "p" is printed 
                                            // instead
                        break;
                    default: // if a number oher than 0 or 1 is printed...
                        aryMap[y][x] = "";  // then print an empty string instead
                        break;
                }
            }
        }

        /*
        For loop used to create the outer walls around the whole array by 
        using a combination of certain indexes to print at certain rows or columns
        */
        for (int xx = 0; xx < aryMap.length; xx++) {
            aryMap[xx][0] = "w";
            aryMap[xx][aryMap.length - 1] = "w";
            aryMap[0][xx] = "w";
            aryMap[aryMap.length - 1][xx] = "w";
        }

        /*
        below are variables used by the loops below
        */
        int randomNumForIteration = randInt(9000, 9000); // CHANGE FOR AMOUNT OF BLOCKS ON SCREEN
        int randomNumForX = 0; // variable used for the x axis
        int randomNumForY = 0; // variable used for the y axis
        int startingValX; // stores the initial value of the randomNumForX variable
        int startingValY; // stores the initial value of the randomNumForY variable

        /*
         Variables for inner wall block
         */
        String tester = "p"; // used to decide what to replace around the structures
                             // if there is something around it
        int wallWidth; // used for the width of the wall structure
        int wallHeight; // used for the height of the wall structure 
        int randIntWidthOne = 1; // CHANGE TO CHOOSE SMALLEST WIDTH A BLOCK CAN BE
        int randIntWidthTwo = 5; // CHANGE TO CHOOSE LARGEST WIDTH A BLOCK CAN BE
        int randomNumForX_Width; // used to randomise width of the wall structure
        int randIntHeightOne = 1; // CHANGE TO CHOOSE SMALLEST HEIGTH BLOCK CAN BE 
        int randIntHeightTwo = 5; // CHANGE TO CHOOSE LARGEST HEIGHT BLOCK CAN BE 
        int randomNumForY_Height; // used to randomise the height of the wall structure

        /*
         Variables for diamond
         */
        int lengthOne = 1; // always one as it is the starting point of the diamond
        int diamondDepth; // used for the depth of the diamond. Actual depth is twice the size + 1 
                          // of what is spcified below
        // ACTUAL DEPTH IS TWICE THE SIZE
        int randIntDepthOne = 1; // CHANGE TO CHOOSE SMALLEST DEPTH A DIAMOND CAN BE
        int randIntDepthTwo = 6; // CHANGE TO CHOOSE LARGEST DEPTH A DIAMOND CAN BE
        int randomNumForDepthRightX; // used to check how far it is from the right hand side of the array 
        int randomNumForDepthLeftX; // used to check how far it is from the left hand side of the array
        int randomNumForDepthY; // used to check how far it is from the bottom of the array 
        int x1; // used to use elsewhere in the code
        

        /*
        The following code is what actually creates sructures such as diamonds of "w" or blocks of "w" on the screen.
        The outer most loop is used to iterate for the amount of blocks on the screen. This may not actially be the case
        as some of the stuctures are covered by the ghost spawn block as it prints on top of everthing underneath it.
        Also, overlapping of normal structures can also reduce the amount of blocks on the screen.
        
        Alot of the variables defined above are assigned values inside of these for loops so that 
        they are assigned new random values each iteration. This helps create random sructures around the array.
        Some of the varibales are used to store the result of the calculation for how far the block is 
        away from the edge of the array.
        
        If statements are used for two reasons. One reason is that they check if there is any "w" surrounding 
        them and if there is, it replaces it with a "p" so that a clear path is made for the user to navigate through the 
        maze. 
        */
        for (int i = 1; i < randomNumForIteration; i++) { // loop for amount of blocks on the screen
            switch (randInt(0, 1)) {
                case 0:
                            
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
                    break;
                case 1:
                    diamondDepth = randInt(randIntDepthOne, randIntDepthTwo);
                    if (true) {
                        randomNumForDepthRightX = (aryMap.length - (randIntDepthTwo + 3)); // calculates space needed from right side
                        randomNumForDepthLeftX = (randIntDepthTwo + 2); // calculates space needed from left hand side
                        randomNumForDepthY = (aryMap.length - ((randIntDepthTwo * 2) + 3)); //calculates space needed from bottom

                    }
                    randomNumForX = randInt(randomNumForDepthLeftX, randomNumForDepthRightX); //sets range for x axis
                    randomNumForY = randInt(2, randomNumForDepthY);  // sets range for y axis;;;
                    
                    
                    startingValX = randomNumForX; // stores initial index used for placing on x axis
                    startingValY = randomNumForY; // stores initial index used for placing on y axis

                    /*
                     for loop for creating the diamond
                     */
                    for (int yyy = 0; yyy < diamondDepth; yyy++) { // depth of the diamond
                        for (x1 = 0; x1 < lengthOne; x1++) { // width, always starts at 1 to make it a full diamond
                            aryMap[randomNumForY][randomNumForX] = "w"; // places "w" at a random spot
                            
                            if (x1 == 0) { // checks top till left side
                                if(aryMap[randomNumForY-1][randomNumForX].equals("w")) { // top
                                    aryMap[randomNumForY-1][randomNumForX] = tester; 
                                } 
                                
                                if(aryMap[randomNumForY-1][randomNumForX-1].equals("w")) { // diagonal top left
                                    aryMap[randomNumForY-1][randomNumForX-1] = tester;
                                }
                            }
                            
                            if(x1 == (lengthOne-1)) { // checks top till right side
                                if(aryMap[randomNumForY-1][randomNumForX].equals("w")) { // up
                                    aryMap[randomNumForY-1][randomNumForX] = tester;
                                }
                                
                                if(aryMap[randomNumForY-1][randomNumForX+1].equals("w")) { // diagonal top right 
                                    aryMap[randomNumForY-1][randomNumForX+1] = tester;
                                }
                            }
                            
                            
                            ++randomNumForX; // move across one on the same line
                        }
                        --startingValX; // start one place behind
                        lengthOne = lengthOne + 2; // increase the total length of line by two
                                                   // so that it starts to make the next line larger 
                        randomNumForX = startingValX; // assign the coordinates to start printing back to the inital value

                        ++randomNumForY; // move to the next line
                        if (yyy == diamondDepth - 1) { // checks whether we have pinted the depth of the array,
                                                       // if this is true... 
                            for (int t = 0; t < lengthOne; t++) { // create the one line in the middle to help 
                                                                  // create the structure of a diamond
                                aryMap[randomNumForY][randomNumForX] = "w";  // print "w" next to each other
                                
                                if (t == 0) { // checks middle line and the most leftest "w"
                                    if(aryMap[randomNumForY-1][randomNumForX].equals("w")) { // top
                                        aryMap[randomNumForY-1][randomNumForX] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY-1][randomNumForX-1].equals("w")) { // diagonal top left
                                        aryMap[randomNumForY-1][randomNumForX-1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY][randomNumForX-1].equals("w")) { // left
                                        aryMap[randomNumForY][randomNumForX-1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY+1][randomNumForX-1].equals("w")) { // diagonal bottom left
                                        aryMap[randomNumForY+1][randomNumForX-1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY+1][randomNumForX].equals("w")) { // down
                                        aryMap[randomNumForY+1][randomNumForX] = tester;
                                    } 
                                }
                                
                                if (t == (lengthOne -1)) { // checks middle line and the most rightest "w"
                                    if(aryMap[randomNumForY-1][randomNumForX].equals("w")) { // top
                                        aryMap[randomNumForY-1][randomNumForX] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY-1][randomNumForX+1].equals("w")) { // diagonal top right
                                        aryMap[randomNumForY-1][randomNumForX+1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY][randomNumForX+1].equals("w")) { // right
                                        aryMap[randomNumForY][randomNumForX+1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY+1][randomNumForX+1].equals("w")) { // diagonal bottom right
                                        aryMap[randomNumForY+1][randomNumForX+1] = tester;
                                    }
                                    
                                    if(aryMap[randomNumForY+1][randomNumForX].equals("w")) { // down
                                        aryMap[randomNumForY+1][randomNumForX] = tester;
                                    }
                                    
                                }
                                
                                ++randomNumForX; // jump to the next line
                            }
                            lengthOne = lengthOne - 2; // decrease size of the next line

                            randomNumForX = startingValX; // choose the value for the starting posiion 
                            ++randomNumForY; // move one line down
                            ++randomNumForX; // move one across
                            startingValX = startingValX + 1; // store initial value 
                            
                            /*
                            loop to create bottom half of diamond
                            */
                            for (yyy = 0; yyy < diamondDepth; yyy++) { // iterates down
                                for (x1 = 0; x1 < lengthOne; x1++) { // iterates across
                                    aryMap[randomNumForY][randomNumForX] = "w";
                                    
                                    if(x1 == 0) { // checks left till bottom
                                        if(aryMap[randomNumForY+1][randomNumForX].equals("w")) { // down
                                            aryMap[randomNumForY+1][randomNumForX] = tester;
                                        }
                                        
                                        if(aryMap[randomNumForY+1][randomNumForX-1].equals("w")) { // diagonal bottom left
                                            aryMap[randomNumForY+1][randomNumForX-1] = tester;
                                        }
                                    }
                                    
                                    if(x1 == lengthOne-1) { // checks right till bottom
                                        if(aryMap[randomNumForY+1][randomNumForX].equals("w")) { // down
                                            aryMap[randomNumForY+1][randomNumForX] = tester;
                                        }
                                        
                                        if(aryMap[randomNumForY+1][randomNumForX+1].equals("w")) { // diagonal bottom right
                                            aryMap[randomNumForY+1][randomNumForX+1] = tester;
                                        }
                                    }
                                    
                                        
                                    
                                    ++randomNumForX; // moves one across
                                }
                                ++startingValX; // moves one down
                                lengthOne = lengthOne - 2; // increases the size of the next line by two
                                randomNumForX = startingValX; // store initial value
                                ++randomNumForY; // move one down
                            }
                        }
                    }
                    lengthOne = 1; // assigns it back to the starting value so that it can 
                                   // be used for the next iteration
                    break;
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
        int depth = 30; // CHANGE TO CHOOSE HEIGHT OF THE GHOST SPAWN BLOCK 
        int width = 30; // CHANGE TO CHOOSE WIDTH OF THE GHOST SPAWN BLOCK

        /*
         Creates ghost spawn block
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

                    if (yy == 0 && xx == width - 1) { // checks "w" on top right
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
                coX = coStartX;
                ++coY;
            }
            coY = coStartY;
        }

        /*
         The loop below fills the inside of the ghost spawn block in pellets.
         */
        ++coX;
        ++coY;
        ++coStartX;

        for (int yyy = 0; yyy < depth - 2; yyy++) {
            for (int xxx = 0; xxx < width - 2; xxx++) {
                aryMap[coY][coX] = "p";
                coX = coX + 1;
            }
            coX = coStartX;
            ++coY;
        }

        
        /*
         search for "p" and "o"
         Used for debugging!!!!!!
         */
        /* <--- take off for using debugging code below
        int counterForP = 0; // counter for "p"
        int counterForO = 0; // counter for "o"
        int counterForD = 0; // counter for "o"
        for (int yyy = 1; yyy < aryMap.length - 1; yyy++) { // height 
            for (int xxx = 1; xxx < aryMap.length - 1; xxx++) { // width
                if (aryMap[yyy][xxx].equals("p")) {  // if "p" is found at this index
                    ++counterForP; // increase counter for "p"
                }
                if (aryMap[yyy][xxx].equals("o")) { // if "o" is found at this index
                    ++counterForO; // increase counter for "o"
                }
                if(aryMap[yyy][xxx].equals("w")) { // if "w" is found within the inner wall
                    ++counterForD; // increament the "d" counter
                }
            }
        }
        System.out.println("P = " + counterForP); // prints it 
        System.out.println("O = " + counterForO); // prints it
        System.out.println("D = " + counterForD); // prints it
        */ //  <----take off for using code above
        return aryMap; // returns the multi-dimentional array filled up
    }

    public static int randInt(int min, int max) { // method to generate random numbers between
        // a certain range
        Random rand = new Random();

        int randomNum = rand.nextInt((max - min) + 1) + min;

        return randomNum;
    }

    public static void printer(String[][] aryMap) { // method that prints the letters

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

           // String[] arrayTwo = new String[100]; // creates array of 100 spaces
            for (int x = 0; x < aryMap.length; x++) { // height
                System.out.println(); // jumps to next line
                bw.write(""); // writes the string 
                for (int y = 0; y < aryMap.length; y++) { // width
                    bw.write(aryMap[x][y]); // writes value in the index to the file
                    System.out.print(aryMap[x][y]);  // places values of array next to each other
                }
                bw.write("\n"); // writes the 'next line' in the file so a new line
                // is represented correctly
                bw.newLine();   // writes a line seperator
            }
            bw.close(); // close stream
            //System.out.println("\nDone");

        } catch (IOException e) { // catches input or output erros  
            e.printStackTrace();
        }
    }
}
