using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x0200446B RID: 17515
	[NullableContext(1)]
	[Nullable(0)]
	public static class FKuroCycleCounter
	{
		// Token: 0x0602E425 RID: 189477
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InitializeEnvironment_Internal();

		// Token: 0x0602E426 RID: 189478 RVA: 0x00ADCFF6 File Offset: 0x00ADB1F6
		public static void InitializeEnvironment()
		{
			FKuroCycleCounter.InitializeEnvironment_Internal();
		}

		// Token: 0x0602E427 RID: 189479
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int CreateCycleCounter_Internal(string Name);

		// Token: 0x0602E428 RID: 189480 RVA: 0x00ADD000 File Offset: 0x00ADB200
		public static int CreateCycleCounter(string statName)
		{
			return FKuroCycleCounter.CreateCycleCounter_Internal(statName);
		}

		// Token: 0x0602E429 RID: 189481
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartCycleCounter_Internal(int StatIndex);

		// Token: 0x0602E42A RID: 189482 RVA: 0x00ADD013 File Offset: 0x00ADB213
		public static void StartCycleCounter(int statIndex)
		{
			FKuroCycleCounter.StartCycleCounter_Internal(statIndex);
		}

		// Token: 0x0602E42B RID: 189483 RVA: 0x00ADD01B File Offset: 0x00ADB21B
		public static void StartCycleCounterByName(FName statName)
		{
			FKuroCycleCounter.StartCycleCounter_Internal(FKuroCycleCounter.CreateCycleCounter_Internal(statName.ToString()));
		}

		// Token: 0x0602E42C RID: 189484
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopCycleCounter_Internal();

		// Token: 0x0602E42D RID: 189485 RVA: 0x00ADD034 File Offset: 0x00ADB234
		public static void StopCycleCounter()
		{
			FKuroCycleCounter.StopCycleCounter_Internal();
		}

		// Token: 0x0602E42E RID: 189486
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DestroyEnvironment_Internal();

		// Token: 0x0602E42F RID: 189487 RVA: 0x00ADD03B File Offset: 0x00ADB23B
		public static void DestroyEnvironment()
		{
			FKuroCycleCounter.DestroyEnvironment_Internal();
		}
	}
}
