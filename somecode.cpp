#include <stdio.h>
#include <string.h>

int main()
{
   char src[40];
   char dest[100];
   char dest2[100];

   printf("Enter your name");
   gets(src); 

   // Copy name from one place to another
   strcpy(dest, src); 
 
   int a = 10;
   int b = 20;
   int c = a+b;
   printf("Result is %d",&c);
 
   strncpy(dest,src, strlen(dest)); 
   
   for (int i=0; i < 10; i++)
   {
      strncat(dest, "this is bad", strlen(dest)); 
   }

   // Some code
   memcpy(dest2, dest, sizeof dest);
 
   return(0);
}