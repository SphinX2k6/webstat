using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;
using UnrealEngine.Utils;

// Token: 0x02000BCF RID: 3023
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CycleCounter : Singleton<CycleCounter>
{
	// Token: 0x060031B0 RID: 12720 RVA: 0x0001E980 File Offset: 0x0001CB80
	public void RefreshState()
	{
		this.SwitchChanged = false;
		if (this.Enabled != this.EnabledNew)
		{
			this.Enabled = this.EnabledNew;
			this.SwitchChanged = true;
			if (!this.Enabled)
			{
				int size = this.NameStack.Size;
				for (int i = 0; i < size; i++)
				{
					FKuroCycleCounter.StopCycleCounter();
				}
				this.NameStack.Clear();
			}
		}
		if (this.NeedCheck != this.NeedCheckNew)
		{
			this.NeedCheck = this.NeedCheckNew;
			this.SwitchChanged = true;
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x060031B1 RID: 12721 RVA: 0x0001EA06 File Offset: 0x0001CC06
	public bool IsEnabled
	{
		get
		{
			return this.Enabled;
		}
	}

	// Token: 0x060031B2 RID: 12722 RVA: 0x0001EA0E File Offset: 0x0001CC0E
	public void SetEnable(bool enabled)
	{
		this.EnabledNew = enabled;
	}

	// Token: 0x060031B3 RID: 12723 RVA: 0x0001EA17 File Offset: 0x0001CC17
	public void SetNeedCheck(bool enable)
	{
		this.NeedCheckNew = enable;
	}

	// Token: 0x060031B4 RID: 12724 RVA: 0x0001EA20 File Offset: 0x0001CC20
	public void Start(string statName)
	{
		if (!this.Enabled)
		{
			return;
		}
		FKuroCycleCounter.StartCycleCounterByName(statName);
		this.CheckStart(statName);
	}

	// Token: 0x060031B5 RID: 12725 RVA: 0x0001EA3D File Offset: 0x0001CC3D
	public void CheckStart(string statName)
	{
		if (this.NeedCheck)
		{
			this.NameStack.Push(statName);
		}
	}

	// Token: 0x060031B6 RID: 12726 RVA: 0x0001EA53 File Offset: 0x0001CC53
	public void Stop(string statName)
	{
		if (!this.Enabled)
		{
			return;
		}
		if (this.IsPassedStackCheck(statName))
		{
			FKuroCycleCounter.StopCycleCounter();
		}
	}

	// Token: 0x060031B7 RID: 12727 RVA: 0x0001EA6C File Offset: 0x0001CC6C
	public bool IsPassedStackCheck(string statName)
	{
		if (!this.NeedCheck)
		{
			return true;
		}
		if (this.NameStack.Size > 0)
		{
			if (statName == this.NameStack.Peek())
			{
				this.NameStack.Pop();
				return true;
			}
			bool flag = false;
			using (IEnumerator<string> enumerator = this.NameStack.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == statName)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				List<string> list = new List<string>();
				list.Add(this.NameStack.Pop());
				string a = list[0];
				while (a != statName)
				{
					FKuroCycleCounter.StopCycleCounter();
					list.Add(this.NameStack.Pop());
					a = list[list.Count - 1];
				}
				UnrealLogger.Error("CycleCounter.Stop()匹配失败，已尝试从栈中恢复 current stat name: " + statName + ", none stopped names: " + string.Join(", ", list));
				return true;
			}
		}
		if (this.SwitchChanged)
		{
			UnrealLogger.Info("CycleCounter.Stop()匹配失败，但当前帧切换过开关状态 name: " + statName);
			return true;
		}
		UnrealLogger.Error("CycleCounter.Stop()匹配失败 name: " + statName);
		return false;
	}

	// Token: 0x0400049D RID: 1181
	public const int STAT_MAX_NAME_LENGTH = 800;

	// Token: 0x0400049E RID: 1182
	private bool Enabled = KuroApplication.IsWithStat();

	// Token: 0x0400049F RID: 1183
	private bool EnabledNew = KuroApplication.IsWithStat();

	// Token: 0x040004A0 RID: 1184
	private bool NeedCheck = !KuroApplication.IsBuildShipping();

	// Token: 0x040004A1 RID: 1185
	private bool NeedCheckNew = !KuroApplication.IsBuildShipping();

	// Token: 0x040004A2 RID: 1186
	private bool SwitchChanged;

	// Token: 0x040004A3 RID: 1187
	private readonly global::Stack<string> NameStack = new global::Stack<string>();
}
