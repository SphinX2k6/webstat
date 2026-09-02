using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F62 RID: 8034
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryQuestItem : UiPanelBase, IGridProxy<EHonamiStoryQuestType>
{
	// Token: 0x0600F088 RID: 61576 RVA: 0x0041BE80 File Offset: 0x0041A080
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F089 RID: 61577 RVA: 0x0041BF8E File Offset: 0x0041A18E
	protected override void OnStart()
	{
		this.TaskLayout = new GenericLayout<HonamiStoryQuestItemChildItem, HonamiStoryQuestDataBase>(base.GetVerticalLayout(1), new Func<HonamiStoryQuestItemChildItem>(this.InitQuestChildItem), null, false, true);
	}

	// Token: 0x0600F08A RID: 61578 RVA: 0x0041BFB4 File Offset: 0x0041A1B4
	private HonamiStoryQuestItemChildItem InitQuestChildItem()
	{
		HonamiStoryQuestItemChildItem honamiStoryQuestItemChildItem = new HonamiStoryQuestItemChildItem();
		if (this.OnClickTask != null)
		{
			honamiStoryQuestItemChildItem.BindOnClickTask(this.OnClickTask);
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "HonamiStoryQuestItem do not have callback", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.TaskChildItemList.Add(honamiStoryQuestItemChildItem);
		return honamiStoryQuestItemChildItem;
	}

	// Token: 0x17001255 RID: 4693
	// (get) Token: 0x0600F08B RID: 61579 RVA: 0x0041C009 File Offset: 0x0041A209
	// (set) Token: 0x0600F08C RID: 61580 RVA: 0x0041C011 File Offset: 0x0041A211
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<EHonamiStoryQuestType>, EHonamiStoryQuestType> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001256 RID: 4694
	// (get) Token: 0x0600F08D RID: 61581 RVA: 0x0041C01A File Offset: 0x0041A21A
	// (set) Token: 0x0600F08E RID: 61582 RVA: 0x0041C022 File Offset: 0x0041A222
	public int GridIndex { get; set; }

	// Token: 0x17001257 RID: 4695
	// (get) Token: 0x0600F08F RID: 61583 RVA: 0x0041C02B File Offset: 0x0041A22B
	// (set) Token: 0x0600F090 RID: 61584 RVA: 0x0041C033 File Offset: 0x0041A233
	public int DisplayIndex { get; set; }

	// Token: 0x0600F091 RID: 61585 RVA: 0x0041C03C File Offset: 0x0041A23C
	public UniTask RefreshAsync(EHonamiStoryQuestType data, bool isSelected, int gridIndex)
	{
		HonamiStoryQuestItem.<RefreshAsync>d__21 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<HonamiStoryQuestItem.<RefreshAsync>d__21>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F092 RID: 61586 RVA: 0x0041C087 File Offset: 0x0041A287
	public void BindOnClickTask(Action<HonamiStoryQuestItemChildItem> callback)
	{
		this.OnClickTask = callback;
	}

	// Token: 0x0600F093 RID: 61587 RVA: 0x0041C090 File Offset: 0x0041A290
	private void RefreshItem()
	{
		if (this.TaskType == EHonamiStoryQuestType.Main)
		{
			base.GetText(2).ShowTextNew("HonamiStory_MainMission");
			return;
		}
		base.GetText(2).ShowTextNew("HonamiStory_SideMission");
	}

	// Token: 0x0600F094 RID: 61588 RVA: 0x0041C0BE File Offset: 0x0041A2BE
	public IReadOnlyList<HonamiStoryQuestItemChildItem> GetTaskChildItemList()
	{
		return this.TaskChildItemList;
	}

	// Token: 0x0600F095 RID: 61589 RVA: 0x0041C0C6 File Offset: 0x0041A2C6
	public void Clear()
	{
	}

	// Token: 0x0600F096 RID: 61590 RVA: 0x0041C0C8 File Offset: 0x0041A2C8
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600F097 RID: 61591 RVA: 0x0041C0CA File Offset: 0x0041A2CA
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600F098 RID: 61592 RVA: 0x0041C0CC File Offset: 0x0041A2CC
	public object GetKey(EHonamiStoryQuestType data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x04007395 RID: 29589
	private EHonamiStoryQuestType TaskType = EHonamiStoryQuestType.Main;

	// Token: 0x04007396 RID: 29590
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryQuestItemChildItem, HonamiStoryQuestDataBase> TaskLayout;

	// Token: 0x04007397 RID: 29591
	private readonly List<HonamiStoryQuestItemChildItem> TaskChildItemList = new List<HonamiStoryQuestItemChildItem>();

	// Token: 0x04007398 RID: 29592
	private int ScrollToHandle = -1;

	// Token: 0x04007399 RID: 29593
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<HonamiStoryQuestItemChildItem> OnClickTask;

	// Token: 0x020082F1 RID: 33521
	[NullableContext(0)]
	private enum EHonamiStoryQuestItemComponent
	{
		// Token: 0x0402C652 RID: 181842
		RootItem,
		// Token: 0x0402C653 RID: 181843
		TaskLayout,
		// Token: 0x0402C654 RID: 181844
		TitleText,
		// Token: 0x0402C655 RID: 181845
		TitleSprite,
		// Token: 0x0402C656 RID: 181846
		TitleItem,
		// Token: 0x0402C657 RID: 181847
		TaskItem,
		// Token: 0x0402C658 RID: 181848
		TitleBgItem
	}
}
