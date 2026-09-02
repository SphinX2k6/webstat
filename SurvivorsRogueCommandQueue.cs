using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AEC RID: 10988
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandQueue
{
	// Token: 0x17001C91 RID: 7313
	// (get) Token: 0x06015F90 RID: 90000 RVA: 0x006196DC File Offset: 0x006178DC
	[Nullable(2)]
	public SurvivorsRogueCommandBase ForegroundCommand
	{
		[NullableContext(2)]
		get
		{
			SurvivorsRogueCommandBase result;
			if (!this.CommandsMap.TryGetValue(this.ForegroundCommandIncId, out result))
			{
				return null;
			}
			return result;
		}
	}

	// Token: 0x06015F91 RID: 90001 RVA: 0x00619704 File Offset: 0x00617904
	public void InitCommands(IList<SurvivorsOpData> dataList)
	{
		this.Commands.Clear();
		this.CommandsMap.Clear();
		for (int i = 0; i < dataList.Count; i++)
		{
			this.AddCommand(dataList[i]);
		}
		this.PrintCommands();
	}

	// Token: 0x06015F92 RID: 90002 RVA: 0x0061974B File Offset: 0x0061794B
	public void Clear()
	{
		this.Commands.Clear();
		this.CommandsMap.Clear();
	}

	// Token: 0x06015F93 RID: 90003 RVA: 0x00619764 File Offset: 0x00617964
	public unsafe void PrintCommands()
	{
		Singleton<Log>.Instance.Info(ELogModule.SurvivorsRogue, ELogAuthor.YYZ, "[SurvivorsRogue] 指令队列打印开始", default(ReadOnlySpan<ValueTuple<string, object>>));
		for (int i = 0; i < this.Commands.Count; i++)
		{
			SurvivorsRogueCommandBase survivorsRogueCommandBase = this.Commands[i];
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[SurvivorsRogue] 指令";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", i);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IncId", survivorsRogueCommandBase.IncId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Data", survivorsRogueCommandBase.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		Singleton<Log>.Instance.Info(ELogModule.SurvivorsRogue, ELogAuthor.YYZ, "[SurvivorsRogue] 指令队列打印结束", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06015F94 RID: 90004 RVA: 0x0061985C File Offset: 0x00617A5C
	public unsafe void AddCommand(SurvivorsOpData data)
	{
		SurvivorsRogueCommandBase survivorsRogueCommandBase = SurvivorsRogueCommandFactory.Create(data);
		if (survivorsRogueCommandBase == null)
		{
			return;
		}
		survivorsRogueCommandBase.Update(data);
		bool foregroundStatus = survivorsRogueCommandBase.IncId == this.ForegroundCommandIncId;
		survivorsRogueCommandBase.SetForegroundStatus(foregroundStatus);
		this.Commands.Add(survivorsRogueCommandBase);
		this.CommandsMap[data.IncId] = survivorsRogueCommandBase;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[SurvivorsRogue] 新增指令";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", this.Commands.Count - 1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IncId", survivorsRogueCommandBase.IncId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Data", survivorsRogueCommandBase.ToString());
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06015F95 RID: 90005 RVA: 0x00619940 File Offset: 0x00617B40
	public void UpdateCommand(SurvivorsOpData data)
	{
		SurvivorsRogueCommandBase survivorsRogueCommandBase;
		if (!this.CommandsMap.TryGetValue(data.IncId, out survivorsRogueCommandBase))
		{
			return;
		}
		survivorsRogueCommandBase.Update(data);
	}

	// Token: 0x06015F96 RID: 90006 RVA: 0x0061996C File Offset: 0x00617B6C
	public unsafe void RemoveCommand(int incId)
	{
		SurvivorsRogueCommandBase survivorsRogueCommandBase;
		if (!this.CommandsMap.TryGetValue(incId, out survivorsRogueCommandBase))
		{
			return;
		}
		survivorsRogueCommandBase.Delete();
		int num = -1;
		for (int i = 0; i < this.Commands.Count; i++)
		{
			if (this.Commands[i].IncId == incId)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			this.Commands.RemoveAt(num);
		}
		this.CommandsMap.Remove(incId);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[SurvivorsRogue] 删除指令";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IncId", incId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06015F97 RID: 90007 RVA: 0x00619A40 File Offset: 0x00617C40
	public void SetForegroundIncId(int incId)
	{
		this.ForegroundCommandIncId = incId;
		for (int i = 0; i < this.Commands.Count; i++)
		{
			SurvivorsRogueCommandBase survivorsRogueCommandBase = this.Commands[i];
			bool foregroundStatus = survivorsRogueCommandBase.IncId == this.ForegroundCommandIncId;
			survivorsRogueCommandBase.SetForegroundStatus(foregroundStatus);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[SurvivorsRogue] 前台指令变更";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ForegroundIncId", incId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015F98 RID: 90008 RVA: 0x00619ABA File Offset: 0x00617CBA
	public void StartForegroundCommand()
	{
		if (this.ForegroundCommand != null)
		{
			this.ForegroundCommand.TryStartExecute();
		}
	}

	// Token: 0x06015F99 RID: 90009 RVA: 0x00619AD0 File Offset: 0x00617CD0
	[NullableContext(2)]
	public SurvivorsRogueCommandBase GetCommandByIncId(int incId)
	{
		SurvivorsRogueCommandBase result;
		if (!this.CommandsMap.TryGetValue(incId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06015F9A RID: 90010 RVA: 0x00619AF0 File Offset: 0x00617CF0
	public IReadOnlyList<SurvivorsRogueCommandBase> GetCommands()
	{
		return this.Commands;
	}

	// Token: 0x0400A8D2 RID: 43218
	private readonly List<SurvivorsRogueCommandBase> Commands = new List<SurvivorsRogueCommandBase>();

	// Token: 0x0400A8D3 RID: 43219
	private readonly Dictionary<int, SurvivorsRogueCommandBase> CommandsMap = new Dictionary<int, SurvivorsRogueCommandBase>();

	// Token: 0x0400A8D4 RID: 43220
	public int ForegroundCommandIncId = -1;
}
