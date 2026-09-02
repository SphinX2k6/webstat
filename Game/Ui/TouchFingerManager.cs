using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A3C RID: 19004
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TouchFingerManager : Singleton<TouchFingerManager>
	{
		// Token: 0x06031A6B RID: 203371 RVA: 0x00C5E92C File Offset: 0x00C5CB2C
		public void Initialize()
		{
			foreach (object obj in Enum.GetValues(typeof(EFingerIndex)))
			{
				EFingerIndex fingerIndex = (EFingerIndex)obj;
				this.NewTouchFingerData(fingerIndex);
			}
		}

		// Token: 0x06031A6C RID: 203372 RVA: 0x00C5E990 File Offset: 0x00C5CB90
		private void NewTouchFingerData(EFingerIndex fingerIndex)
		{
			TouchFingerData value = new TouchFingerData(fingerIndex);
			this.TouchFingerDataMap[fingerIndex] = value;
		}

		// Token: 0x06031A6D RID: 203373 RVA: 0x00C5E9B4 File Offset: 0x00C5CBB4
		[NullableContext(2)]
		public TouchFingerData GetTouchFingerData(EFingerIndex fingerIndex)
		{
			TouchFingerData result;
			if (this.TouchFingerDataMap.TryGetValue(fingerIndex, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06031A6E RID: 203374 RVA: 0x00C5E9D4 File Offset: 0x00C5CBD4
		public void StartTouch(EFingerIndex fingerIndex, FVector touchPosition)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return;
			}
			if (touchFingerData.IsInTouch())
			{
				return;
			}
			this.CurrentTouchFingerCount++;
			touchFingerData.StartTouch(touchPosition);
		}

		// Token: 0x06031A6F RID: 203375 RVA: 0x00C5EA0C File Offset: 0x00C5CC0C
		public void EndTouch(EFingerIndex fingerIndex)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return;
			}
			if (!touchFingerData.IsInTouch())
			{
				return;
			}
			this.CurrentTouchFingerCount = Math.Max(this.CurrentTouchFingerCount - 1, 0);
			touchFingerData.EndTouch();
		}

		// Token: 0x06031A70 RID: 203376 RVA: 0x00C5EA48 File Offset: 0x00C5CC48
		public void MoveTouch(EFingerIndex fingerIndex, FVector touchPosition)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return;
			}
			touchFingerData.MoveTouch(touchPosition);
		}

		// Token: 0x06031A71 RID: 203377 RVA: 0x00C5EA68 File Offset: 0x00C5CC68
		public FVector? GetTouchPosition(EFingerIndex fingerIndex)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return null;
			}
			if (!touchFingerData.IsInTouch())
			{
				return null;
			}
			return touchFingerData.GetTouchPosition();
		}

		// Token: 0x06031A72 RID: 203378 RVA: 0x00C5EAA4 File Offset: 0x00C5CCA4
		public FVector? GetLastTouchPosition(EFingerIndex fingerIndex)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return null;
			}
			if (!touchFingerData.IsInTouch())
			{
				return null;
			}
			return touchFingerData.GetLastTouchPosition();
		}

		// Token: 0x06031A73 RID: 203379 RVA: 0x00C5EADE File Offset: 0x00C5CCDE
		public int GetTouchFingerCount()
		{
			return this.CurrentTouchFingerCount;
		}

		// Token: 0x06031A74 RID: 203380 RVA: 0x00C5EAE8 File Offset: 0x00C5CCE8
		public float GetFingerExpandCloseValue(EFingerIndex aFingerIndex, EFingerIndex bFingerIndex)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(aFingerIndex);
			TouchFingerData touchFingerData2 = this.GetTouchFingerData(bFingerIndex);
			if (touchFingerData == null || touchFingerData2 == null)
			{
				return 0f;
			}
			if (!touchFingerData2.IsInTouch() || !touchFingerData.IsInTouch())
			{
				return 0f;
			}
			FVector? lastTouchPosition = touchFingerData.GetLastTouchPosition();
			FVector? lastTouchPosition2 = touchFingerData2.GetLastTouchPosition();
			if (lastTouchPosition == null || lastTouchPosition2 == null)
			{
				return 0f;
			}
			FVector? touchPosition = touchFingerData.GetTouchPosition();
			FVector? touchPosition2 = touchFingerData2.GetTouchPosition();
			if (touchPosition == null || touchPosition2 == null)
			{
				return 0f;
			}
			float num = touchPosition.Value.X - touchPosition2.Value.X;
			float num2 = touchPosition.Value.Y - touchPosition2.Value.Y;
			float num3 = touchPosition.Value.Z - touchPosition2.Value.Z;
			float num4 = lastTouchPosition.Value.X - lastTouchPosition2.Value.X;
			float num5 = lastTouchPosition.Value.Y - lastTouchPosition2.Value.Y;
			float num6 = lastTouchPosition.Value.Z - lastTouchPosition2.Value.Z;
			float num7 = num * num + num2 * num2 + num3 * num3;
			float num8 = num4 * num4 + num5 * num5 + num6 * num6;
			return num7 - num8;
		}

		// Token: 0x06031A75 RID: 203381 RVA: 0x00C5EC3C File Offset: 0x00C5CE3C
		[return: TupleElementNames(new string[]
		{
			"State",
			"ChangeRate"
		})]
		public ValueTuple<EFingerExpandCloseType, float> GetFingerExpandCloseType(EFingerIndex aFingerIndex, EFingerIndex bFingerIndex)
		{
			float num = 0f;
			TouchFingerData touchFingerData = this.GetTouchFingerData(aFingerIndex);
			TouchFingerData touchFingerData2 = this.GetTouchFingerData(bFingerIndex);
			EFingerExpandCloseType item;
			if (touchFingerData == null || touchFingerData2 == null)
			{
				item = EFingerExpandCloseType.None;
				return new ValueTuple<EFingerExpandCloseType, float>(item, num);
			}
			if (!touchFingerData2.IsInTouch() || !touchFingerData.IsInTouch())
			{
				item = EFingerExpandCloseType.None;
				return new ValueTuple<EFingerExpandCloseType, float>(item, num);
			}
			FVector? lastTouchPosition = touchFingerData.GetLastTouchPosition();
			FVector? lastTouchPosition2 = touchFingerData2.GetLastTouchPosition();
			if (lastTouchPosition == null || lastTouchPosition2 == null)
			{
				item = EFingerExpandCloseType.None;
				return new ValueTuple<EFingerExpandCloseType, float>(item, num);
			}
			FVector? touchPosition = touchFingerData.GetTouchPosition();
			FVector? touchPosition2 = touchFingerData2.GetTouchPosition();
			if (touchPosition == null || touchPosition2 == null)
			{
				item = EFingerExpandCloseType.None;
				return new ValueTuple<EFingerExpandCloseType, float>(item, num);
			}
			float num2 = UKismetMathLibrary.Vector_DistanceSquared(touchPosition.Value, touchPosition2.Value);
			float num3 = UKismetMathLibrary.Vector_DistanceSquared(lastTouchPosition.Value, lastTouchPosition2.Value);
			num = (num2 - num3) / num3;
			if (Math.Abs(num) <= 0.001f)
			{
				item = EFingerExpandCloseType.None;
			}
			else if (num > 0f)
			{
				item = EFingerExpandCloseType.Expand;
			}
			else
			{
				item = EFingerExpandCloseType.Close;
			}
			return new ValueTuple<EFingerExpandCloseType, float>(item, num);
		}

		// Token: 0x06031A76 RID: 203382 RVA: 0x00C5ED38 File Offset: 0x00C5CF38
		[return: TupleElementNames(new string[]
		{
			"X",
			"Y"
		})]
		public ValueTuple<float, float>? GetFingerDirection(EFingerIndex fingerIndex)
		{
			TouchFingerData touchFingerData = this.GetTouchFingerData(fingerIndex);
			if (touchFingerData == null)
			{
				return null;
			}
			if (!touchFingerData.IsInTouch())
			{
				return null;
			}
			FVector? lastTouchPosition = touchFingerData.GetLastTouchPosition();
			FVector? touchPosition = touchFingerData.GetTouchPosition();
			if (lastTouchPosition == null || touchPosition == null)
			{
				return new ValueTuple<float, float>?(new ValueTuple<float, float>(0f, 0f));
			}
			return new ValueTuple<float, float>?(new ValueTuple<float, float>(touchPosition.Value.X - lastTouchPosition.Value.X, touchPosition.Value.Y - lastTouchPosition.Value.Y));
		}

		// Token: 0x0401CE64 RID: 118372
		[Nullable(1)]
		private readonly Dictionary<EFingerIndex, TouchFingerData> TouchFingerDataMap = new Dictionary<EFingerIndex, TouchFingerData>();

		// Token: 0x0401CE65 RID: 118373
		public int CurrentTouchFingerCount;
	}
}
