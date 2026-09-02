using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.UI.Framework;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A1E RID: 18974
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class Input : Singleton<Input>
	{
		// Token: 0x0603193A RID: 203066 RVA: 0x00C5B044 File Offset: 0x00C59244
		public void Initialize(LGUIEventSystemActor_C eventActor)
		{
			if (eventActor == null)
			{
				return;
			}
			eventActor.OnClickKey.Add(new Action<FKey, bool>(this.OnKeyClick));
			eventActor.OnMiddleMouseScroll.Add(new Action<float>(this.OnMiddleMouseScroll));
			eventActor.OnTouch.Add(new Action<bool, int, FVector>(this.OnTouch));
			eventActor.OnTouchMove.Add(new Action<int, FVector>(this.OnTouchMove));
		}

		// Token: 0x0603193B RID: 203067 RVA: 0x00C5B0B4 File Offset: 0x00C592B4
		public bool IsKeyPress(string key)
		{
			bool flag;
			return this.KeyMap.TryGetValue(key, out flag) && flag;
		}

		// Token: 0x0603193C RID: 203068 RVA: 0x00C5B0D4 File Offset: 0x00C592D4
		public float GetAxisValue()
		{
			return this.AxisValue;
		}

		// Token: 0x0603193D RID: 203069 RVA: 0x00C5B0DC File Offset: 0x00C592DC
		public IReadOnlyDictionary<int, TouchData> GetTouchMap()
		{
			return this.TouchMap;
		}

		// Token: 0x0603193E RID: 203070 RVA: 0x00C5B0E4 File Offset: 0x00C592E4
		private void OnKeyClick(FKey key, bool isPress)
		{
			string text = key.KeyName.ToString();
			this.KeyMap[text] = isPress;
			if ((StringUtils.IsEmpty(this.OnlyRespondToKey) || text == this.OnlyRespondToKey || text.Contains("Mouse")) && this.Enable)
			{
				this.KeyMap[text] = isPress;
				Singleton<EventSystem>.Instance.Emit<bool, FKey>(EEventName.KeyClick, isPress, key);
			}
		}

		// Token: 0x0603193F RID: 203071 RVA: 0x00C5B15E File Offset: 0x00C5935E
		private void OnMiddleMouseScroll(float axisValue)
		{
			if (this.Enable)
			{
				this.AxisValue = axisValue;
			}
		}

		// Token: 0x06031940 RID: 203072 RVA: 0x00C5B170 File Offset: 0x00C59370
		private void OnTouch(bool isPress, int touchId, FVector touchPosition)
		{
			TouchData value;
			if (this.Enable && !this.TouchMap.TryGetValue(touchId, out value))
			{
				value = new TouchData(isPress, touchId, touchPosition);
				this.TouchMap[touchId] = value;
			}
		}

		// Token: 0x06031941 RID: 203073 RVA: 0x00C5B1AC File Offset: 0x00C593AC
		private void OnTouchMove(int touchId, FVector touchPosition)
		{
			TouchData touchData;
			if (this.Enable && this.TouchMap.TryGetValue(touchId, out touchData))
			{
				touchData.TouchPosition = touchPosition;
			}
		}

		// Token: 0x0401CDED RID: 118253
		private readonly Dictionary<string, bool> KeyMap = new Dictionary<string, bool>();

		// Token: 0x0401CDEE RID: 118254
		private readonly Dictionary<int, TouchData> TouchMap = new Dictionary<int, TouchData>();

		// Token: 0x0401CDEF RID: 118255
		private float AxisValue;

		// Token: 0x0401CDF0 RID: 118256
		public string OnlyRespondToKey = "";

		// Token: 0x0401CDF1 RID: 118257
		public bool Enable = true;
	}
}
