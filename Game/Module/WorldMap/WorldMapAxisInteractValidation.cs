using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B19 RID: 19225
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapAxisInteractValidation
	{
		// Token: 0x0603227A RID: 205434 RVA: 0x00C8D8C0 File Offset: 0x00C8BAC0
		public void Reset()
		{
			this.ViewOpened = false;
			foreach (string axisName in new List<string>(this.AxisInValidationMap.Keys))
			{
				this.InitAxisLock(axisName);
			}
		}

		// Token: 0x0603227B RID: 205435 RVA: 0x00C8D924 File Offset: 0x00C8BB24
		public void InitAxisLock(string axisName)
		{
			bool value = ModelBase<InputDistributeModel>.Instance.GetAxisValue(axisName) != 0f;
			this.AxisInValidationMap[axisName] = value;
		}

		// Token: 0x0603227C RID: 205436 RVA: 0x00C8D954 File Offset: 0x00C8BB54
		public void Init()
		{
			this.AddEventListener();
		}

		// Token: 0x0603227D RID: 205437 RVA: 0x00C8D95C File Offset: 0x00C8BB5C
		public void Clear()
		{
			this.RemoveEventListener();
			this.AxisInValidationMap.Clear();
			this.ViewOpened = false;
		}

		// Token: 0x0603227E RID: 205438 RVA: 0x00C8D976 File Offset: 0x00C8BB76
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapViewOpened, new Action(this.OnMapViewOpened));
		}

		// Token: 0x0603227F RID: 205439 RVA: 0x00C8D994 File Offset: 0x00C8BB94
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapViewOpened, new Action(this.OnMapViewOpened));
		}

		// Token: 0x06032280 RID: 205440 RVA: 0x00C8D9B4 File Offset: 0x00C8BBB4
		public void InputAxis(string axisName, float value)
		{
			if (this.IsAxisInValid(axisName) && this.ViewOpened && value == 0f)
			{
				foreach (string key in new List<string>(this.AxisInValidationMap.Keys))
				{
					this.AxisInValidationMap[key] = false;
				}
			}
		}

		// Token: 0x1700859E RID: 34206
		// (get) Token: 0x06032281 RID: 205441 RVA: 0x00C8DA30 File Offset: 0x00C8BC30
		public bool IsInValid
		{
			get
			{
				using (Dictionary<string, bool>.ValueCollection.Enumerator enumerator = this.AxisInValidationMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x06032282 RID: 205442 RVA: 0x00C8DA8C File Offset: 0x00C8BC8C
		public bool IsAxisInValid(string axisName)
		{
			return this.AxisInValidationMap.GetValueOrDefault(axisName, false);
		}

		// Token: 0x06032283 RID: 205443 RVA: 0x00C8DA9B File Offset: 0x00C8BC9B
		private void OnMapViewOpened()
		{
			this.ViewOpened = true;
		}

		// Token: 0x0401D4F5 RID: 120053
		private bool ViewOpened;

		// Token: 0x0401D4F6 RID: 120054
		private readonly Dictionary<string, bool> AxisInValidationMap = new Dictionary<string, bool>();
	}
}
