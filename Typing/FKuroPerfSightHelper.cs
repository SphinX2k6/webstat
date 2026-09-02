using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x0200446D RID: 17517
	[NullableContext(1)]
	[Nullable(0)]
	public class FKuroPerfSightHelper
	{
		// Token: 0x0602E435 RID: 189493
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnRegisterTickGroupEvent_Internal();

		// Token: 0x0602E436 RID: 189494 RVA: 0x00ADD04A File Offset: 0x00ADB24A
		public static void UnRegisterTickGroupEvent()
		{
			FKuroPerfSightHelper.UnRegisterTickGroupEvent_Internal();
		}

		// Token: 0x0602E437 RID: 189495
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnRegisterOnFrameBegin_Internal();

		// Token: 0x0602E438 RID: 189496 RVA: 0x00ADD051 File Offset: 0x00ADB251
		public static void UnRegisterOnFrameBegin()
		{
			FKuroPerfSightHelper.UnRegisterOnFrameBegin_Internal();
		}

		// Token: 0x0602E439 RID: 189497
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetStrategyById_Internal(int strategyId, int strategyValue);

		// Token: 0x0602E43A RID: 189498 RVA: 0x00ADD058 File Offset: 0x00ADB258
		public static void SetStrategyById(int strategyId, int strategyValue)
		{
			FKuroPerfSightHelper.SetStrategyById_Internal(strategyId, strategyValue);
		}

		// Token: 0x0602E43B RID: 189499
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFlameGraphStrMapSize_Internal(int inSize);

		// Token: 0x0602E43C RID: 189500 RVA: 0x00ADD061 File Offset: 0x00ADB261
		public static void SetFlameGraphStrMapSize(int inSize)
		{
			FKuroPerfSightHelper.SetFlameGraphStrMapSize_Internal(inSize);
		}

		// Token: 0x0602E43D RID: 189501
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFlameGraphQueueSize_Internal(int length);

		// Token: 0x0602E43E RID: 189502 RVA: 0x00ADD069 File Offset: 0x00ADB269
		public static void SetFlameGraphQueueSize(int length)
		{
			FKuroPerfSightHelper.SetFlameGraphQueueSize_Internal(length);
		}

		// Token: 0x0602E43F RID: 189503
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFlameGraphDropThresholds_Internal(int threshold);

		// Token: 0x0602E440 RID: 189504 RVA: 0x00ADD071 File Offset: 0x00ADB271
		public static void SetFlameGraphDropThresholds(int threshold)
		{
			FKuroPerfSightHelper.SetFlameGraphDropThresholds_Internal(threshold);
		}

		// Token: 0x0602E441 RID: 189505
		[NullableContext(0)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void SafePushCall_Internal(char* callGraphName);

		// Token: 0x0602E442 RID: 189506 RVA: 0x00ADD07C File Offset: 0x00ADB27C
		[NullableContext(2)]
		public unsafe static void SafePushCall(string callGraphName)
		{
			if (callGraphName == null)
			{
				callGraphName = string.Empty;
			}
			char* callGraphName2;
			if (callGraphName == null)
			{
				callGraphName2 = null;
			}
			else
			{
				fixed (char* ptr = callGraphName.GetPinnableReference())
				{
					callGraphName2 = ptr;
				}
			}
			FKuroPerfSightHelper.SafePushCall_Internal(callGraphName2);
			char* ptr = null;
		}

		// Token: 0x0602E443 RID: 189507
		[NullableContext(0)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void SafePopCall_Internal(char* callGraphName);

		// Token: 0x0602E444 RID: 189508 RVA: 0x00ADD0AC File Offset: 0x00ADB2AC
		[NullableContext(2)]
		public unsafe static void SafePopCall(string callGraphName)
		{
			if (callGraphName == null)
			{
				callGraphName = string.Empty;
			}
			char* callGraphName2;
			if (callGraphName == null)
			{
				callGraphName2 = null;
			}
			else
			{
				fixed (char* ptr = callGraphName.GetPinnableReference())
				{
					callGraphName2 = ptr;
				}
			}
			FKuroPerfSightHelper.SafePopCall_Internal(callGraphName2);
			char* ptr = null;
		}

		// Token: 0x0602E445 RID: 189509
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterTickGroupEvent_Internal();

		// Token: 0x0602E446 RID: 189510 RVA: 0x00ADD0DB File Offset: 0x00ADB2DB
		public static void RegisterTickGroupEvent()
		{
			FKuroPerfSightHelper.RegisterTickGroupEvent_Internal();
		}

		// Token: 0x0602E447 RID: 189511
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterOnFrameBegin_Internal(in FString callGraphName);

		// Token: 0x0602E448 RID: 189512 RVA: 0x00ADD0E4 File Offset: 0x00ADB2E4
		public unsafe static void RegisterOnFrameBegin(string callGraphName)
		{
			FString fstring = FString.AllocTemp(callGraphName);
			FKuroPerfSightHelper.RegisterOnFrameBegin_Internal(fstring);
			FString.NativeDestruct(&fstring, 1);
		}

		// Token: 0x0602E449 RID: 189513
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueString_Internal(in FString category, in FString key, in FString value);

		// Token: 0x0602E44A RID: 189514 RVA: 0x00ADD108 File Offset: 0x00ADB308
		public unsafe static void PostValueString(string category, string key, string value)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FString fstring3 = FString.AllocTemp(value);
			FKuroPerfSightHelper.PostValueString_Internal(fstring, fstring2, fstring3);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
			FString.NativeDestruct(&fstring3, 1);
		}

		// Token: 0x0602E44B RID: 189515
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueInteger3_Internal(in FString category, in FString key, int valueA, int valueB, int valueC);

		// Token: 0x0602E44C RID: 189516 RVA: 0x00ADD150 File Offset: 0x00ADB350
		public unsafe static void PostValueInteger3(string category, string key, int valueA, int valueB, int valueC)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueInteger3_Internal(fstring, fstring2, valueA, valueB, valueC);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E44D RID: 189517
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueInteger2_Internal(in FString category, in FString key, int valueA, int valueB);

		// Token: 0x0602E44E RID: 189518 RVA: 0x00ADD18C File Offset: 0x00ADB38C
		public unsafe static void PostValueInteger2(string category, string key, int valueA, int valueB)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueInteger2_Internal(fstring, fstring2, valueA, valueB);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E44F RID: 189519
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueInteger1_Internal(in FString category, in FString key, int valueA);

		// Token: 0x0602E450 RID: 189520 RVA: 0x00ADD1C4 File Offset: 0x00ADB3C4
		public unsafe static void PostValueInteger1(string category, string key, int valueA)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueInteger1_Internal(fstring, fstring2, valueA);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E451 RID: 189521
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueFloat3_Internal(in FString category, in FString key, float valueA, float valueB, float valueC);

		// Token: 0x0602E452 RID: 189522 RVA: 0x00ADD1FC File Offset: 0x00ADB3FC
		public unsafe static void PostValueFloat3(string category, string key, float valueA, float valueB, float valueC)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueFloat3_Internal(fstring, fstring2, valueA, valueB, valueC);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E453 RID: 189523
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueFloat2_Internal(in FString category, in FString key, float valueA, float valueB);

		// Token: 0x0602E454 RID: 189524 RVA: 0x00ADD238 File Offset: 0x00ADB438
		public unsafe static void PostValueFloat2(string category, string key, float valueA, float valueB)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueFloat2_Internal(fstring, fstring2, valueA, valueB);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E455 RID: 189525
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostValueFloat1_Internal(in FString category, in FString key, float valueA);

		// Token: 0x0602E456 RID: 189526 RVA: 0x00ADD270 File Offset: 0x00ADB470
		public unsafe static void PostValueFloat1(string category, string key, float valueA)
		{
			FString fstring = FString.AllocTemp(category);
			FString fstring2 = FString.AllocTemp(key);
			FKuroPerfSightHelper.PostValueFloat1_Internal(fstring, fstring2, valueA);
			FString.NativeDestruct(&fstring, 1);
			FString.NativeDestruct(&fstring2, 1);
		}

		// Token: 0x0602E457 RID: 189527
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PostFrame_Internal(float deltaTime);

		// Token: 0x0602E458 RID: 189528 RVA: 0x00ADD2A7 File Offset: 0x00ADB4A7
		public static void PostFrame(float deltaTime)
		{
			FKuroPerfSightHelper.PostFrame_Internal(deltaTime);
		}

		// Token: 0x0602E459 RID: 189529
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MarkStartUpFinish_Internal();

		// Token: 0x0602E45A RID: 189530 RVA: 0x00ADD2AF File Offset: 0x00ADB4AF
		public static void MarkStartUpFinish()
		{
			FKuroPerfSightHelper.MarkStartUpFinish_Internal();
		}

		// Token: 0x0602E45B RID: 189531
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsOnFrameBeginRegistered_Internal();

		// Token: 0x0602E45C RID: 189532 RVA: 0x00ADD2B6 File Offset: 0x00ADB4B6
		public static bool IsOnFrameBeginRegistered()
		{
			return FKuroPerfSightHelper.IsOnFrameBeginRegistered_Internal();
		}

		// Token: 0x0602E45D RID: 189533
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsBeginCallGraphCalled_Internal();

		// Token: 0x0602E45E RID: 189534 RVA: 0x00ADD2BD File Offset: 0x00ADB4BD
		public static bool IsBeginCallGraphCalled()
		{
			return FKuroPerfSightHelper.IsBeginCallGraphCalled_Internal();
		}

		// Token: 0x0602E45F RID: 189535
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EndExtTag_Internal(in FString tagName);

		// Token: 0x0602E460 RID: 189536 RVA: 0x00ADD2C4 File Offset: 0x00ADB4C4
		public unsafe static void EndExtTag(string tagName)
		{
			FString fstring = FString.AllocTemp(tagName);
			FKuroPerfSightHelper.EndExtTag_Internal(fstring);
			FString.NativeDestruct(&fstring, 1);
		}

		// Token: 0x0602E461 RID: 189537
		[NullableContext(0)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void EndCallGraph_Internal(char* name);

		// Token: 0x0602E462 RID: 189538 RVA: 0x00ADD2E8 File Offset: 0x00ADB4E8
		[NullableContext(2)]
		public unsafe static void EndCallGraph(string name)
		{
			if (name == null)
			{
				name = string.Empty;
			}
			char* name2;
			if (name == null)
			{
				name2 = null;
			}
			else
			{
				fixed (char* ptr = name.GetPinnableReference())
				{
					name2 = ptr;
				}
			}
			FKuroPerfSightHelper.EndCallGraph_Internal(name2);
			char* ptr = null;
		}

		// Token: 0x0602E463 RID: 189539
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableTimedReport_Internal();

		// Token: 0x0602E464 RID: 189540 RVA: 0x00ADD317 File Offset: 0x00ADB517
		public static void EnableTimedReport()
		{
			FKuroPerfSightHelper.EnableTimedReport_Internal();
		}

		// Token: 0x0602E465 RID: 189541
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginExtTag_Internal(in FString tagName);

		// Token: 0x0602E466 RID: 189542 RVA: 0x00ADD320 File Offset: 0x00ADB520
		public unsafe static void BeginExtTag(string tagName)
		{
			FString fstring = FString.AllocTemp(tagName);
			FKuroPerfSightHelper.BeginExtTag_Internal(fstring);
			FString.NativeDestruct(&fstring, 1);
		}

		// Token: 0x0602E467 RID: 189543
		[NullableContext(0)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void BeginCallGraph_Internal(char* name);

		// Token: 0x0602E468 RID: 189544 RVA: 0x00ADD344 File Offset: 0x00ADB544
		[NullableContext(2)]
		public unsafe static void BeginCallGraph(string name)
		{
			if (name == null)
			{
				name = string.Empty;
			}
			char* name2;
			if (name == null)
			{
				name2 = null;
			}
			else
			{
				fixed (char* ptr = name.GetPinnableReference())
				{
					name2 = ptr;
				}
			}
			FKuroPerfSightHelper.BeginCallGraph_Internal(name2);
			char* ptr = null;
		}
	}
}
