﻿using System;
using System.Drawing;
using System.Collections;

using ZedGraph;

namespace ZedGraph.Demo
{
	/// <summary>
	/// Summary description for SimpleDemo.
	/// </summary>
	public class MasterSampleDemo : DemoBase
	{

		public MasterSampleDemo() : base( "Code Project MasterPane Sample",
				"MasterPane Sample", DemoType.Tutorial )
		{
			MasterPane myMaster = base.MasterPane;
			myMaster.MarginAll = 10;
			myMaster.IsShowTitle = true;
			myMaster.PaneList.Remove(0);

			myMaster.Title = "ZedGraph MasterPane Example";
			myMaster.PaneFill = new Fill( Color.White, Color.MediumSlateBlue, 45.0F );

			myMaster.Legend.IsVisible = true;
			myMaster.Legend.Position = LegendPos.TopCenter;

			TextItem text = new TextItem( "Priority", 0.88F, 0.12F );
			text.Location.CoordinateFrame = CoordType.PaneFraction;
			text.FontSpec.Angle = 15.0F;
			text.FontSpec.FontColor = Color.Red;
			text.FontSpec.IsBold = true;
			text.FontSpec.Size = 16;
			text.FontSpec.Border.IsVisible = false;
			text.FontSpec.Border.Color = Color.Red;
			text.FontSpec.Fill.IsVisible = false;
			text.Location.AlignH = AlignH.Left;
			text.Location.AlignV = AlignV.Bottom;
			myMaster.GraphItemList.Add( text );

			text = new TextItem( "DRAFT", 0.5F, 0.5F );
			text.Location.CoordinateFrame = CoordType.PaneFraction;
			text.FontSpec.Angle = 30.0F;
			text.FontSpec.FontColor = Color.FromArgb( 70, 255, 100, 100 );
			text.FontSpec.IsBold = true;
			text.FontSpec.Size = 100;
			text.FontSpec.Border.IsVisible = false;
			text.FontSpec.Fill.IsVisible = false;
			text.Location.AlignH = AlignH.Center;
			text.Location.AlignV = AlignV.Center;
			text.ZOrder = ZOrder.A_InFront;
			myMaster.GraphItemList.Add( text );

			ColorSymbolRotator rotator = new ColorSymbolRotator();

			for ( int j=0; j<5; j++ )
			{
				// Create a new graph - rect dimensions do not matter here, since it
				// will be resized by MasterPane.AutoPaneLayout()
				GraphPane myPane = new GraphPane( new Rectangle( 10, 10, 10, 10 ),
					"Case #" + (j+1).ToString(),
					"Time, Days",
					"Rate, m/s" );

				myPane.PaneFill = new Fill( Color.White, Color.LightYellow, 45.0F );
				myPane.BaseDimension = 6.0F;

				// Make up some data arrays based on the Sine function
				double x, y;
				PointPairList list = new PointPairList();
				for ( int i=0; i<36; i++ )
				{
					x = (double) i + 5;
					y = 3.0 * ( 1.5 + Math.Sin( (double) i * 0.2 + (double) j ) );
					list.Add( x, y );
				}

				LineItem myCurve = myPane.AddCurve( "Type " + j.ToString(),
					list, rotator.NextColor, rotator.NextSymbol );
				myCurve.Symbol.Fill = new Fill( Color.White );

				myMaster.Add( myPane );
			}

			Graphics g = this.ZedGraphControl.CreateGraphics();

			myMaster.AutoPaneLayout( g, PaneLayout.ExplicitRow32 );
			myMaster.AxisChange( g );

			g.Dispose();
		}
	}
}


