using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004477 RID: 17527
	public static class KuroScreen
	{
		// Token: 0x0602E4B6 RID: 189622
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double ComputePhysicalScreenDensity_Internal();

		// Token: 0x0602E4B7 RID: 189623 RVA: 0x00ADD5A6 File Offset: 0x00ADB7A6
		public static double ComputePhysicalScreenDensity()
		{
			return KuroScreen.ComputePhysicalScreenDensity_Internal();
		}

		// Token: 0x0602E4B8 RID: 189624
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetPhysicalScreenDensityDPI_Internal();

		// Token: 0x0602E4B9 RID: 189625 RVA: 0x00ADD5AD File Offset: 0x00ADB7AD
		public static double GetPhysicalScreenDensityDPI()
		{
			return KuroScreen.GetPhysicalScreenDensityDPI_Internal();
		}

		// Token: 0x0602E4BA RID: 189626
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FVector2D GetDisplayScreenResolution_Internal();

		// Token: 0x0602E4BB RID: 189627 RVA: 0x00ADD5B4 File Offset: 0x00ADB7B4
		public static FVector2D GetDisplayScreenResolution()
		{
			return KuroScreen.GetDisplayScreenResolution_Internal();
		}

		// Token: 0x0602E4BC RID: 189628
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FVector2D GetPhysicalScreenResolution_Internal();

		// Token: 0x0602E4BD RID: 189629 RVA: 0x00ADD5BB File Offset: 0x00ADB7BB
		public static FVector2D GetPhysicalScreenResolution()
		{
			return KuroScreen.GetPhysicalScreenResolution_Internal();
		}

		// Token: 0x0602E4BE RID: 189630
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FVector2D GetPhysicalScreenResolutionV2_Internal();

		// Token: 0x0602E4BF RID: 189631 RVA: 0x00ADD5C2 File Offset: 0x00ADB7C2
		public static FVector2D GetPhysicalScreenResolutionV2()
		{
			return KuroScreen.GetPhysicalScreenResolutionV2_Internal();
		}

		// Token: 0x0602E4C0 RID: 189632
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetScreenLogicalDensity_Internal();

		// Token: 0x0602E4C1 RID: 189633 RVA: 0x00ADD5C9 File Offset: 0x00ADB7C9
		public static double GetScreenLogicalDensity()
		{
			return KuroScreen.GetScreenLogicalDensity_Internal();
		}

		// Token: 0x0602E4C2 RID: 189634
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetScreenScaledDensity_Internal();

		// Token: 0x0602E4C3 RID: 189635 RVA: 0x00ADD5D0 File Offset: 0x00ADB7D0
		public static double GetScreenScaledDensity()
		{
			return KuroScreen.GetScreenScaledDensity_Internal();
		}

		// Token: 0x0602E4C4 RID: 189636
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern double GetScreenDensityDPI_Internal();

		// Token: 0x0602E4C5 RID: 189637 RVA: 0x00ADD5D7 File Offset: 0x00ADB7D7
		public static double GetScreenDensityDPI()
		{
			return KuroScreen.GetScreenDensityDPI_Internal();
		}
	}
}
