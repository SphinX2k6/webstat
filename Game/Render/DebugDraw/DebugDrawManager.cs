using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render.DebugDraw
{
	// Token: 0x0200479E RID: 18334
	public class DebugDrawManager : IStaticVariableResetter
	{
		// Token: 0x0602F927 RID: 194855 RVA: 0x00B56860 File Offset: 0x00B54A60
		protected static void EnsureInstance()
		{
			if (DebugDrawManager.Instance != null)
			{
				return;
			}
			DebugDrawManager.Instance = new DebugDrawManager();
			DebugDrawManager.Instance.Counter = 0;
			DebugDrawManager.Instance.DebugDrawMap = new Dictionary<int, DebugDrawManager.EffectDebugDrawInfo>();
		}

		// Token: 0x0602F928 RID: 194856 RVA: 0x00B56890 File Offset: 0x00B54A90
		[NullableContext(1)]
		public static int AddDebugLineFromPlayer(Vector toLocation, FLinearColor color, float width)
		{
			DebugDrawManager.EnsureInstance();
			DebugDrawManager.EffectDebugDrawInfo effectDebugDrawInfo = new DebugDrawManager.EffectDebugDrawInfo();
			effectDebugDrawInfo.Index = DebugDrawManager.Instance.Counter;
			effectDebugDrawInfo.Type = new DebugDrawManager.EEffectDebugDrawType?(DebugDrawManager.EEffectDebugDrawType.LineFromPlayer);
			effectDebugDrawInfo.VectorA = toLocation;
			effectDebugDrawInfo.ColorA = new FLinearColor?(color);
			effectDebugDrawInfo.NumberA = width;
			DebugDrawManager.Instance.DebugDrawMap.Add(effectDebugDrawInfo.Index, effectDebugDrawInfo);
			DebugDrawManager.Instance.Counter++;
			return effectDebugDrawInfo.Index;
		}

		// Token: 0x0602F929 RID: 194857 RVA: 0x00B5690C File Offset: 0x00B54B0C
		public static int AddDebugBox(FBox box, FLinearColor color, float width)
		{
			DebugDrawManager.EnsureInstance();
			DebugDrawManager.EffectDebugDrawInfo effectDebugDrawInfo = new DebugDrawManager.EffectDebugDrawInfo();
			effectDebugDrawInfo.Index = DebugDrawManager.Instance.Counter;
			effectDebugDrawInfo.Type = new DebugDrawManager.EEffectDebugDrawType?(DebugDrawManager.EEffectDebugDrawType.Box);
			effectDebugDrawInfo.ColorA = new FLinearColor?(color);
			effectDebugDrawInfo.NumberA = width;
			effectDebugDrawInfo.BoxA = new FBox?(box);
			DebugDrawManager.Instance.DebugDrawMap.Add(effectDebugDrawInfo.Index, effectDebugDrawInfo);
			DebugDrawManager.Instance.Counter++;
			return effectDebugDrawInfo.Index;
		}

		// Token: 0x0602F92A RID: 194858 RVA: 0x00B5698D File Offset: 0x00B54B8D
		public static void RemoveDebugDraw(int index)
		{
			if (DebugDrawManager.Instance == null)
			{
				return;
			}
			DebugDrawManager.Instance.DebugDrawMap.Remove(index);
		}

		// Token: 0x0602F92B RID: 194859 RVA: 0x00B569A8 File Offset: 0x00B54BA8
		public static void ClearDebugDraw()
		{
			if (DebugDrawManager.Instance == null)
			{
				return;
			}
			DebugDrawManager.Instance.DebugDrawMap.Clear();
		}

		// Token: 0x0602F92C RID: 194860 RVA: 0x00B569C1 File Offset: 0x00B54BC1
		public static void Initialize()
		{
		}

		// Token: 0x0602F92D RID: 194861 RVA: 0x00B569C4 File Offset: 0x00B54BC4
		public static void Tick(float delta)
		{
			if (DebugDrawManager.Instance == null)
			{
				return;
			}
			float duration = 0.01f;
			foreach (KeyValuePair<int, DebugDrawManager.EffectDebugDrawInfo> keyValuePair in DebugDrawManager.Instance.DebugDrawMap)
			{
				DebugDrawManager.EffectDebugDrawInfo value = keyValuePair.Value;
				DebugDrawManager.EEffectDebugDrawType value2 = value.Type.Value;
				if (value2 != DebugDrawManager.EEffectDebugDrawType.LineFromPlayer)
				{
					if (value2 == DebugDrawManager.EEffectDebugDrawType.Box)
					{
						UObject world = GlobalData.World;
						FVector fvector = value.BoxA.Value.Min + value.BoxA.Value.Max;
						FVectorDouble center = UKismetMathLibrary.Conv_VectorToVectorDouble(fvector / 2f);
						FVector fvector2 = value.BoxA.Value.Max - value.BoxA.Value.Min;
						UKismetSystemLibrary.D_DrawDebugBox(world, center, UKismetMathLibrary.Conv_VectorToVectorDouble(fvector2 / 2f), value.ColorA.Value, default(FRotator), duration, value.NumberA);
					}
				}
				else
				{
					UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, Singleton<RenderDataManager>.Instance.GetCurrentCharacterPosition().ToUeVector(false), value.VectorA.ToUeVector(false), value.ColorA.Value, duration, value.NumberA);
				}
			}
		}

		// Token: 0x0602F92E RID: 194862 RVA: 0x00B56B3C File Offset: 0x00B54D3C
		public static void Destroy()
		{
			if (DebugDrawManager.Instance == null)
			{
				return;
			}
			DebugDrawManager.Instance = null;
		}

		// Token: 0x0602F92F RID: 194863 RVA: 0x00B56B4C File Offset: 0x00B54D4C
		static DebugDrawManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(DebugDrawManager.CreateStaticDefaultValue), new Action(DebugDrawManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602F930 RID: 194864 RVA: 0x00B56B6B File Offset: 0x00B54D6B
		public static void CreateStaticDefaultValue()
		{
			DebugDrawManager.Instance = null;
		}

		// Token: 0x0602F931 RID: 194865 RVA: 0x00B56B73 File Offset: 0x00B54D73
		public static void ResetStaticDefaultValue()
		{
			DebugDrawManager.Instance = null;
		}

		// Token: 0x0401B35F RID: 111455
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, DebugDrawManager.EffectDebugDrawInfo> DebugDrawMap;

		// Token: 0x0401B360 RID: 111456
		protected int Counter;

		// Token: 0x0401B361 RID: 111457
		[Nullable(2)]
		protected static DebugDrawManager Instance;

		// Token: 0x0200A892 RID: 43154
		public enum EEffectDebugDrawType
		{
			// Token: 0x040344E4 RID: 214244
			LineFromPlayer,
			// Token: 0x040344E5 RID: 214245
			Box
		}

		// Token: 0x0200A893 RID: 43155
		public class EffectDebugDrawInfo
		{
			// Token: 0x040344E6 RID: 214246
			public int Index;

			// Token: 0x040344E7 RID: 214247
			public DebugDrawManager.EEffectDebugDrawType? Type;

			// Token: 0x040344E8 RID: 214248
			[Nullable(2)]
			public Vector VectorA;

			// Token: 0x040344E9 RID: 214249
			public FLinearColor? ColorA;

			// Token: 0x040344EA RID: 214250
			public float NumberA;

			// Token: 0x040344EB RID: 214251
			public FBox? BoxA;
		}
	}
}
