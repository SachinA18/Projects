#include <iostream>
#include <fstream>
#include <string>
using namespace std;

class Game

{
    protected :
        int Lv = 0 , Msc ;
        char Id ;
    public :
        void fninGame (int a , int b , char c)
        {
            Msc = a ; Lv = b ; Id = c ;
        }
} ;

class Play : protected Game

{
    public :
        int x ;
        void fnplay ()
        {
            cout << "\n1.Play New Match \n2.Resume Game \n3.Level Details \nAny Number.Exit \n\nWhat is Your Choice : " ; cin >> x ;
            switch (x)
            {
                case 1 :

                    {
                        ofstream outf ("Player.txt");
                        cout << "\nEnter Your Id : " ; cin >> Id ;
                        outf << Id << endl;

                        cout << "\nMain Menu - Please Enter 0\n" ;

                        do{
                            cout << "\n\nEnter Match Score : "; cin >> Msc ;

                            Lv = Lv + Msc ;

                        }while (Msc != 0);

                        outf << Lv << endl;

                        return fnplay ();

                        break ;

                        }
                case 2 :
                    {
                        ofstream outf ("Player.txt");
                        ifstream inf ("player.txt");
                        inf >> Id ;
                        inf >> Lv ;

                        cout << "\nMain Menu - Please Enter 0\n" ;

                        do{
                            cout << "\nEnter Match Score : "; cin >> Msc ;

                            Lv = Lv + Msc ;

                        }while (Msc != 0);

                        outf << Id << endl;
                        outf << Lv << endl;

                        return fnplay ();

                        break ;

                        }
                case 3 :
                    {
                        ifstream inf ("Player.txt");
                        inf >> Id ;
                        inf >> Lv ;
                        if (Lv > 0 && Lv < 1000)
                            {
                                cout << "\nPlayer ID - " << Id << endl;
                                cout << Lv << "/1000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 1          |\n-----------------------------\n";
                            }
                        else if (Lv > 1000 && Lv < 2000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/2000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 2          |\n-----------------------------\n";
                            }
                        else if (Lv > 2000 && Lv < 3000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/3000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 3          |\n-----------------------------\n";
                            }
                        else if (Lv > 3000 && Lv < 4000)
                            {
                                cout << Lv << "/4000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 4          |\n-----------------------------\n";
                            }
                        else if (Lv > 1000 && Lv < 2000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/5000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 5          |\n-----------------------------\n";
                            }
                        else if (Lv > 5000 && Lv < 6000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/6000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 6          |\n-----------------------------\n";
                            }
                        else if (Lv > 6000 && Lv < 7000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/7000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 7          |\n-----------------------------\n";
                            }
                        else if (Lv > 7000 && Lv < 8000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/8000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 8          |\n-----------------------------\n";
                            }
                        else if (Lv > 9000 && Lv < 10000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << Lv << "/9000" << endl;
                                cout << "\n-----------------------------\n|          LEVEL 9          |\n-----------------------------\n";
                            }
                        else if (Lv > 10000)
                            {
                                cout << "Player ID - " << Id << endl;
                                cout << "\n-----------------------------\n|          LEVEL 10         |\n-----------------------------\n";
                                cout << "\n-----------------------------\n|          HIGH LEVEL       |\n-----------------------------\n";
                                cout << "\nLV -" << Lv << endl;
                            }
                        return fnplay ();

                        break ;
                    }


                default :
                    {
                        break ;
                    }
            }
        }

};

main ()

{
    Play g ;
    g.fnplay ();
}
