// TasterDay2_SE.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <random>
using namespace std;

int main()
{
    const int MIN = 1;
    const int MAX = 10;

    //random number generator
    random_device seed;
    mt19937 gen{ seed() };
    uniform_int_distribution<> dist{ MIN, MAX };
    int numToGuess = dist(gen);

    int userGuess;
    int countGuesses = 0;
    vector<int> prevGuesses;

    //loop until user guessed number
    do
    {
        countGuesses++;
        cout << "Please input a number between " << MIN
            << " and " << MAX << endl;
        cout << "These are your previous input" << endl;

        //loop through previous gusses
        for (int guess : prevGuesses)
        {
            cout << guess << ", ";
        }

        cout << endl;
        cin >> userGuess;

        //check if guess is too small
        if (userGuess < numToGuess)
        {
            cout << "Your guess is too small" << endl;
        }
        //check if guess is too big
        else if (userGuess > numToGuess)
        {
            cout << "Your guess it too large" << endl;
        }
        
        prevGuesses.push_back(userGuess);
    } while (numToGuess != userGuess);

    cout << "Hooray! You guessed the number!" <<
        "The number is " << numToGuess 
        << " It took you " << countGuesses <<
        " guesses" << endl;
}