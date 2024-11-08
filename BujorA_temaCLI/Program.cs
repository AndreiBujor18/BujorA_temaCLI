using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class InteractiveWindow : GameWindow
{
    private float x = 0.0f;
    private float y = 0.0f;

    public InteractiveWindow() : base(800, 600, GraphicsMode.Default, "TemaLab2") { }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(0.5f, 0.5f, 0.5f, 0.5f); //culoare fundal
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        if (Keyboard.GetState().IsKeyDown(Key.W)) //WASD
            y += 0.05f;

        if (Keyboard.GetState().IsKeyDown(Key.S))
            y -= 0.05f;  // Mutăm obiectul în jos

        if (Keyboard.GetState().IsKeyDown(Key.A))
            x -= 0.05f;

        if (Keyboard.GetState().IsKeyDown(Key.D))
            x += 0.05f;
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);

        x = (e.X - Width / 2) / (Width / 2.0f); //Mouse
        y = -(e.Y - Height / 2) / (Height / 2.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.Begin(PrimitiveType.Quads); //Patrat alb
        GL.Color3(1f, 1f, 1f);
        GL.Vertex2(x - 0.05f, y - 0.05f);
        GL.Vertex2(x + 0.05f, y - 0.05f);
        GL.Vertex2(x + 0.05f, y + 0.05f);
        GL.Vertex2(x - 0.05f, y + 0.05f);
        GL.End();

        SwapBuffers();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        GL.Viewport(0, 0, Width, Height);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);
        GL.MatrixMode(MatrixMode.Modelview);
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.Key == Key.Escape) //ESC
            this.Close();
    }

    static void Main(string[] args)
    {
        using (InteractiveWindow window = new InteractiveWindow())
        {
            window.Run(60.0); //60 fps uri
        }
    }
}
