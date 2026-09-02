using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200242D RID: 9261
[NullableContext(1)]
[Nullable(0)]
public class PersonalHeadPhotoComponent : UiPanelBase
{
	// Token: 0x17001693 RID: 5779
	// (get) Token: 0x06011E8A RID: 73354 RVA: 0x004ECF98 File Offset: 0x004EB198
	[Nullable(2)]
	private PlayerHeadData CurSelectPlayerHead
	{
		[NullableContext(2)]
		get
		{
			int selectedGridIndex = this.ScrollView.GetGenericLayout().GetSelectedGridIndex();
			if (selectedGridIndex < 0 || selectedGridIndex >= this.PlayerHeadDataList.Count)
			{
				return null;
			}
			return this.PlayerHeadDataList[selectedGridIndex];
		}
	}

	// Token: 0x06011E8B RID: 73355 RVA: 0x004ECFD8 File Offset: 0x004EB1D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06011E8C RID: 73356 RVA: 0x004ED048 File Offset: 0x004EB248
	protected override void OnStart()
	{
		this.PlayerHeadDataList = ModelBase<PersonalModel>.Instance.GetPlayerShowHeadDataList();
		this.ScrollView = new GenericScrollViewNew<PersonalRoleSmallItemGrid, PlayerHeadData>(base.GetScrollViewWithScrollbar(0), new Func<PersonalRoleSmallItemGrid>(this.CreateCardItem), null, false, null);
		this.AddEventListener();
	}

	// Token: 0x06011E8D RID: 73357 RVA: 0x004ED084 File Offset: 0x004EB284
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PersonalHeadPhotoComponent.<OnBeforeShowAsyncImplement>d__7 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PersonalHeadPhotoComponent.<OnBeforeShowAsyncImplement>d__7>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011E8E RID: 73358 RVA: 0x004ED0C7 File Offset: 0x004EB2C7
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x06011E8F RID: 73359 RVA: 0x004ED0CF File Offset: 0x004EB2CF
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHeadIconChange, new Action<int>(this.RefreshView));
	}

	// Token: 0x06011E90 RID: 73360 RVA: 0x004ED0ED File Offset: 0x004EB2ED
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHeadIconChange, new Action<int>(this.RefreshView));
	}

	// Token: 0x06011E91 RID: 73361 RVA: 0x004ED10B File Offset: 0x004EB30B
	public void OnClickConfirm(int _)
	{
		ControllerBase<PersonalController>.Instance.SendChangeHeadPhotoRequest(this.CurSelectPlayerHead.Id);
	}

	// Token: 0x06011E92 RID: 73362 RVA: 0x004ED122 File Offset: 0x004EB322
	public void SetRefreshConfirmBtn(Action<bool, bool> refreshConfirmBtn)
	{
		this.RefreshConfirmBtn = refreshConfirmBtn;
	}

	// Token: 0x06011E93 RID: 73363 RVA: 0x004ED12C File Offset: 0x004EB32C
	private void RefreshView(int roleId)
	{
		this.PlayerHeadDataList = this.GetSortedList();
		this.ScrollView.RefreshByData(this.PlayerHeadDataList, null, false);
		for (int i = 0; i < this.PlayerHeadDataList.Count; i++)
		{
			this.ScrollView.GetScrollItemByIndex(i).RefreshEquipHeadIconItem();
		}
		int index = 0;
		this.ScrollView.ScrollTo(this.ScrollView.GetItemByIndex(index), false);
		this.SelectByRoleId(this.PlayerHeadDataList[index]);
	}

	// Token: 0x06011E94 RID: 73364 RVA: 0x004ED1AB File Offset: 0x004EB3AB
	private PersonalRoleSmallItemGrid CreateCardItem()
	{
		PersonalRoleSmallItemGrid personalRoleSmallItemGrid = new PersonalRoleSmallItemGrid();
		personalRoleSmallItemGrid.BindToggleClickCallBack(new Action<PlayerHeadData>(this.RoleItemToggleClick));
		return personalRoleSmallItemGrid;
	}

	// Token: 0x06011E95 RID: 73365 RVA: 0x004ED1C4 File Offset: 0x004EB3C4
	private void RoleItemToggleClick(PlayerHeadData playerHeadData)
	{
		this.SelectByRoleId(playerHeadData);
	}

	// Token: 0x06011E96 RID: 73366 RVA: 0x004ED1D0 File Offset: 0x004EB3D0
	private void SelectByRoleId(PlayerHeadData playerHeadData)
	{
		int num = this.PlayerHeadDataList.FindIndex((PlayerHeadData data) => data == playerHeadData);
		GenericScrollViewNew<PersonalRoleSmallItemGrid, PlayerHeadData> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			GenericLayout<PersonalRoleSmallItemGrid, PlayerHeadData> genericLayout = scrollView.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(num, false);
			}
		}
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.ScrollView.GetItemByIndex(num), true, false, false);
		int headPhotoId = ModelBase<PersonalModel>.Instance.GetHeadPhotoId();
		bool arg = !playerHeadData.Lock && headPhotoId != playerHeadData.Id;
		if (this.RefreshConfirmBtn != null)
		{
			this.RefreshConfirmBtn(arg, headPhotoId == playerHeadData.Id);
		}
		UUITexture roleTexture = base.GetTexture(1);
		roleTexture.SetUIActive(false);
		base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), roleTexture, delegate(bool _)
		{
			roleTexture.SetUIActive(true);
		});
		base.GetText(2).ShowTextNew(playerHeadData.GetName());
		UUIText text = base.GetText(3);
		text.SetUIActive(playerHeadData.Lock);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, playerHeadData.Config.Tips, Array.Empty<object>());
	}

	// Token: 0x06011E97 RID: 73367 RVA: 0x004ED31C File Offset: 0x004EB51C
	private List<PlayerHeadData> GetSortedList()
	{
		List<PlayerHeadData> list = ModelBase<PersonalModel>.Instance.GetPlayerShowHeadDataList().ToList<PlayerHeadData>();
		int num = list.FindIndex((PlayerHeadData data) => data.Id == ModelBase<PersonalModel>.Instance.GetHeadPhotoId());
		if (num <= 0 || num >= list.Count)
		{
			return list;
		}
		PlayerHeadData value = list[num];
		for (int i = num; i > 0; i--)
		{
			list[i] = list[i - 1];
		}
		list[0] = value;
		return list;
	}

	// Token: 0x04008C46 RID: 35910
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PersonalRoleSmallItemGrid, PlayerHeadData> ScrollView;

	// Token: 0x04008C47 RID: 35911
	protected List<PlayerHeadData> PlayerHeadDataList = new List<PlayerHeadData>();

	// Token: 0x04008C48 RID: 35912
	[Nullable(2)]
	private Action<bool, bool> RefreshConfirmBtn;
}
