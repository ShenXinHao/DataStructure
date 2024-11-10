// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
int Search(int[] nums, int target) {
    var left = 0;
    var right = nums.Length - 1;
    while(left <= right)
    {
        var middle = left + ((right - left)/2);
        if(nums[middle] > target)
        {
            right = middle - 1;
        }
        else if(nums[middle] < target)
        {
            left = middle + 1;
        }
        else{
            return middle;
        }
    }
    return -1;
}
 
Search(new int[] { -1,0,3,5,9,12}, 9);