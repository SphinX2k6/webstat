using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200344D RID: 13389
[NullableContext(1)]
[Nullable(0)]
public class CombatScriptHelperBase
{
	// Token: 0x0601C150 RID: 115024 RVA: 0x00860C70 File Offset: 0x0085EE70
	public void Init()
	{
		if (this.IsInit)
		{
			return;
		}
		this.Clear();
		this.OnInit();
		foreach (CombatScriptSet combatScriptSet in this.CombatScripts)
		{
			foreach (CombatScriptUnit combatScriptUnit in combatScriptSet.CombatScriptUnits)
			{
				this.CombatScriptNames.Add(combatScriptUnit.Cmd);
				this.UeCombatScriptNames.Add(combatScriptUnit.Cmd);
			}
		}
		this.IsInit = true;
	}

	// Token: 0x0601C151 RID: 115025 RVA: 0x00860D34 File Offset: 0x0085EF34
	private void Clear()
	{
		this.CombatScripts.Clear();
		this.CombatScriptNames.Clear();
		this.UeCombatScriptNames.Empty(true);
	}

	// Token: 0x0601C152 RID: 115026 RVA: 0x00860D58 File Offset: 0x0085EF58
	public virtual void OnInit()
	{
	}

	// Token: 0x0601C153 RID: 115027 RVA: 0x00860D5C File Offset: 0x0085EF5C
	public string FilterCmd(string cmd)
	{
		string text = cmd;
		foreach (CombatScriptSet combatScriptSet in this.CombatScripts)
		{
			if (cmd == combatScriptSet.GetType().Name)
			{
				return combatScriptSet.OnFilterCmd();
			}
			foreach (CombatScriptUnit combatScriptUnit in combatScriptSet.CombatScriptUnits)
			{
				int num = text.IndexOf(combatScriptUnit.Cmd, StringComparison.Ordinal);
				if (num >= 0)
				{
					text = text.Remove(num, combatScriptUnit.Cmd.Length).Insert(num, combatScriptUnit.Body);
				}
			}
		}
		return text;
	}

	// Token: 0x17002648 RID: 9800
	// (get) Token: 0x0601C154 RID: 115028 RVA: 0x00860E48 File Offset: 0x0085F048
	public TArray<string> CombatScriptIndexes
	{
		get
		{
			this.Init();
			return this.UeCombatScriptNames;
		}
	}

	// Token: 0x0601C155 RID: 115029 RVA: 0x00860E58 File Offset: 0x0085F058
	[return: Nullable(2)]
	public CombatScriptSet GetCombatScriptBaseByName(string name)
	{
		foreach (CombatScriptSet combatScriptSet in this.CombatScripts)
		{
			if (combatScriptSet.GetType().Name == name)
			{
				return combatScriptSet;
			}
		}
		return null;
	}

	// Token: 0x0400E2D6 RID: 58070
	protected readonly List<CombatScriptSet> CombatScripts = new List<CombatScriptSet>();

	// Token: 0x0400E2D7 RID: 58071
	protected readonly List<string> CombatScriptNames = new List<string>();

	// Token: 0x0400E2D8 RID: 58072
	protected readonly TArray<string> UeCombatScriptNames = new TArray<string>();

	// Token: 0x0400E2D9 RID: 58073
	protected bool IsInit;
}
