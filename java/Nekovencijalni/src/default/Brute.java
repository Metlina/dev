/**
 * Created by tinop on 07-Dec-15.
 */
public class Brute {
    public static long timeEnd;

    public static void possibleStrings(int maxLength, char[] alphabet, String curr, String tmp) {
        // If the current string has reached it's maximum length
        if (curr.length() == maxLength) {
            if (curr.equals(tmp)) {
                timeEnd = System.currentTimeMillis();
                System.out.println(curr);
            }

        // Else add each letter from the alphabet to new strings and process these new strings again
        } else {
            for (char anAlphabet : alphabet) {
                String oldCurr = curr;
                curr += anAlphabet;
                possibleStrings(maxLength, alphabet, curr, tmp);
                curr = oldCurr;
            }
        }
    }
}
