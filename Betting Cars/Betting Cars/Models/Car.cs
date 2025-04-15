public class Car
{
    public string Name { get; set; }
    public Image Image { get; set; }
    public int Speed { get; private set; }
    public int Position { get; set; }
    public PictureBox PictureBox { get; set; }

    public Car(string name, Image image, PictureBox pictureBox)
    {
        Name = name;
        Image = image;
        PictureBox = pictureBox;
        Position = 0;
        Speed = 0;
        pictureBox.Image = image;
    }

    public void Accelerate(Random random)
    {
        Speed = random.Next(1, 10);
        Position += Speed;
    }

    public void Reset()
    {
        Position = 0;
        Speed = 0;
    }
}