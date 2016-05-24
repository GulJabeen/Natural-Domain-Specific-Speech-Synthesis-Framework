using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace NDSSSF.Droid
{
    class BorderDrawer
    {
        public static ImageView generateBorderImageView(Context context, int borderWidth, int borderHeight, int borderThickness, int color)
        {
            ImageView mask = new ImageView(context);

            // Create the square to serve as the mask
            Bitmap squareMask = Bitmap.CreateBitmap(borderWidth - (borderThickness * 2), borderHeight - (borderThickness * 2), Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(squareMask);

            Paint paint = new Paint();
            paint.SetStyle(Paint.Style.Fill);
            paint.Color.ToArgb();
            canvas.DrawRect(0.0f, 0.0f, (float)borderWidth, (float)borderHeight, paint);

            // Create the darkness bitmap
            Bitmap solidColor = Bitmap.CreateBitmap(borderWidth, borderHeight, Bitmap.Config.Argb8888);
            canvas = new Canvas(solidColor);

            paint.SetStyle(Paint.Style.Fill);
          //  paint.setColor(color);
            canvas.DrawRect(0.0f, 0.0f, borderWidth, borderHeight, paint);

            // Create the masked version of the darknessView
            Bitmap borderBitmap = Bitmap.CreateBitmap(borderWidth, borderHeight, Bitmap.Config.Argb8888);
            canvas = new Canvas(borderBitmap);

            Paint clearPaint = new Paint();
            clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));

            canvas.DrawBitmap(solidColor, 0, 0, null);
            canvas.DrawBitmap(squareMask, borderThickness, borderThickness, clearPaint);

            clearPaint.SetXfermode(null);

            ImageView borderView = new ImageView(context);
            borderView.SetImageBitmap(borderBitmap);

            return borderView;
        }
    }
}