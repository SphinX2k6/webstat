using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048B8 RID: 18616
	[NullableContext(1)]
	[Nullable(0)]
	public class DecorationItem
	{
		// Token: 0x0603087D RID: 198781 RVA: 0x00BEAB18 File Offset: 0x00BE8D18
		public DecorationItem(BaseOutlookComponent owner, USkeletalMeshComponent parentMesh, int index, bool alwaysUpdate, bool needDelayShow)
		{
			this.Owner = owner;
			this.ParentMesh = parentMesh;
			this.Index = index;
			this.AlwaysUpdate = alwaysUpdate;
			this.NeedDelayShow = needDelayShow;
			this.TagComp = this.Owner.Entity.GetComponent<BaseTagComponent>();
			this.UeSkelTickMgrComp = this.Owner.Entity.GetComponent<UeSkeletalTickManageComponent>();
			AActor owner2 = this.ParentMesh.GetOwner();
			TSubclassOf<UActorComponent> @class = USkeletalMeshComponent.StaticClass();
			bool bManualAttachment = false;
			FTransform ftransform = new FTransform();
			this.MeshComp = (owner2.AddComponentByClass(@class, bManualAttachment, ftransform, false, new FName("Dec" + this.Index.ToString())) as USkeletalMeshComponent);
			this.MeshComp.SetComponentTickEnabled(false);
			this.MeshComp.K2_AttachToComponent(this.ParentMesh, FNameUtil.NONE, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
			UeSkeletalTickManageComponent ueSkelTickMgrComp = this.UeSkelTickMgrComp;
			if (ueSkelTickMgrComp != null)
			{
				ueSkelTickMgrComp.AddOrRefreshSkeletalMeshComponent(this.MeshComp);
			}
			UeSkeletalTickManageComponent ueSkelTickMgrComp2 = this.UeSkelTickMgrComp;
			if (ueSkelTickMgrComp2 == null)
			{
				return;
			}
			ueSkelTickMgrComp2.EnableOrDisableSkelTick(this.MeshComp, false);
		}

		// Token: 0x170082C0 RID: 33472
		// (get) Token: 0x0603087E RID: 198782 RVA: 0x00BEAC42 File Offset: 0x00BE8E42
		// (set) Token: 0x0603087F RID: 198783 RVA: 0x00BEAC4A File Offset: 0x00BE8E4A
		public BaseOutlookComponent Owner { get; set; }

		// Token: 0x170082C1 RID: 33473
		// (get) Token: 0x06030880 RID: 198784 RVA: 0x00BEAC53 File Offset: 0x00BE8E53
		// (set) Token: 0x06030881 RID: 198785 RVA: 0x00BEAC5B File Offset: 0x00BE8E5B
		public USkeletalMeshComponent ParentMesh { get; set; }

		// Token: 0x170082C2 RID: 33474
		// (get) Token: 0x06030882 RID: 198786 RVA: 0x00BEAC64 File Offset: 0x00BE8E64
		// (set) Token: 0x06030883 RID: 198787 RVA: 0x00BEAC6C File Offset: 0x00BE8E6C
		public int Index { get; set; }

		// Token: 0x170082C3 RID: 33475
		// (get) Token: 0x06030884 RID: 198788 RVA: 0x00BEAC75 File Offset: 0x00BE8E75
		// (set) Token: 0x06030885 RID: 198789 RVA: 0x00BEAC7D File Offset: 0x00BE8E7D
		protected bool AlwaysUpdate { get; set; }

		// Token: 0x170082C4 RID: 33476
		// (get) Token: 0x06030886 RID: 198790 RVA: 0x00BEAC86 File Offset: 0x00BE8E86
		// (set) Token: 0x06030887 RID: 198791 RVA: 0x00BEAC8E File Offset: 0x00BE8E8E
		protected bool NeedDelayShow { get; set; }

		// Token: 0x06030888 RID: 198792 RVA: 0x00BEAC98 File Offset: 0x00BE8E98
		private void ResetMeshAnimationState()
		{
			if (this.MeshComp == null || !UKismetSystemLibrary.IsValid(this.MeshComp))
			{
				return;
			}
			UKuroAnimLibrary.EndAnimNotifyStates(this.MeshComp.GetAnimInstance());
			this.MeshComp.SetComponentTickEnabled(false);
			this.MeshComp.SetAnimClass(default(UClassStackOnlyPtr));
			this.MeshComp.SetMasterPoseComponent(null, false);
			this.MeshComp.SetVisibility(false, false);
		}

		// Token: 0x06030889 RID: 198793 RVA: 0x00BEAD08 File Offset: 0x00BE8F08
		public unsafe bool SetDecorationId(int newId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Decoration;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[Decoration] Equip Decoration";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Index", this.Index);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("From", this.CurrentConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("To", newId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			if (this.CurrentConfigId == newId)
			{
				return true;
			}
			if (this.MeshComp == null)
			{
				return false;
			}
			this.CurrentConfigId = newId;
			if (newId == 0)
			{
				this.DisableSkeletalMesh();
				return true;
			}
			SDecorationConfig modelConfig = DataTableUtil.GetDataTableRowFromName<SDecorationConfig>(EDataTable.DecorationConfig, newId.ToString());
			if (modelConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Decoration;
				ELogAuthor author2 = ELogAuthor.LCZ;
				string message2 = "[Decoration] Equip Decoration Error. 缺失DT配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Id", newId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("DecConfigId", newId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				this.DisableSkeletalMesh();
				return false;
			}
			this.RequireVisible = true;
			this.DestroyEffects();
			this.AddTagsListenerInMap(this.DisplayTags, newId, modelConfig.DisplayTags.GameplayTags);
			this.AddTagsListenerInMap(this.HideTags, newId, modelConfig.HideTags.GameplayTags);
			this.Visible = this.ComputeFinalVisible();
			string path = modelConfig.SkeletalMesh.ToAssetPathName();
			Action<UClass, string> <>9__1;
			Singleton<ResourceSystem>.Instance.LoadAsync<USkeletalMesh>(path, delegate([Nullable(2)] USkeletalMesh skelMesh, string _)
			{
				if (this.MeshComp == null || !UKismetSystemLibrary.IsValid(this.MeshComp))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Decoration;
					ELogAuthor author3 = ELogAuthor.CWZ;
					string message3 = "[Decoration] Mesh Load Finished but MeshComp is invalid, skip";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Id", newId);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					return;
				}
				if (this.CurrentConfigId != newId || skelMesh == null || !UKismetSystemLibrary.IsValid(skelMesh))
				{
					this.ResetMeshAnimationState();
					USkeletalMeshComponent meshComp = this.MeshComp;
					if (meshComp == null)
					{
						return;
					}
					meshComp.SetSkeletalMesh(null, true);
					return;
				}
				else
				{
					this.ResetMeshAnimationState();
					this.MeshComp.SetSkeletalMesh(skelMesh, true);
					bool flag = this.ComputeFinalVisible();
					if (!modelConfig.SetMasterFollow)
					{
						this.MeshComp.SetMasterPoseComponent(null, false);
						string text = modelConfig.AnimBlueprint.ToAssetPathName();
						if (!string.IsNullOrEmpty(text))
						{
							ResourceSystem instance4 = Singleton<ResourceSystem>.Instance;
							string path2 = text;
							Action<UClass, string> callback;
							if ((callback = <>9__1) == null)
							{
								callback = (<>9__1 = delegate([Nullable(2)] UClass abpClass, string _)
								{
									if (this.CurrentConfigId != newId)
									{
										return;
									}
									this.MeshComp.SetAnimClass(abpClass.ClassStackOnlyPtr);
									this.MeshComp.SetComponentTickEnabled(this.Visible);
								});
							}
							instance4.LoadAsync<UClass>(path2, callback, 100, "js_undefined");
						}
						else
						{
							this.MeshComp.SetComponentTickEnabled(flag);
						}
						FName socketName = (modelConfig.AttachSocket.Num() > 0) ? modelConfig.AttachSocket.Get(0) : FNameUtil.NONE;
						this.MeshComp.K2_AttachToComponent(this.ParentMesh, socketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
						if (modelConfig.AttachTrans.Num() > 0)
						{
							Transform transform = DecorationItem.tmpTrans;
							FTransform ftransform = modelConfig.AttachTrans.Get(0);
							transform.FromUeTransform(ftransform);
						}
						else
						{
							DecorationItem.tmpTrans.SetLocation(Vector.ZeroVectorProxy);
							DecorationItem.tmpTrans.SetRotation(Quat.IdentityProxy);
							DecorationItem.tmpTrans.SetLocation(Vector.OneVectorProxy);
						}
						FHitResult fhitResult = new FHitResult();
						USceneComponent meshComp2 = this.MeshComp;
						FTransformDouble ftransformDouble = DecorationItem.tmpTrans.ToUeTransform();
						meshComp2.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
						this.SpawnEffects(newId, modelConfig, flag);
						this.ApplyPresentationVisibility("SetDecorationId", flag);
						return;
					}
					USkeletalMeshComponent subMeshComponent = this.GetSubMeshComponent(modelConfig.SubMeshName);
					if (subMeshComponent == null || !UKismetSystemLibrary.IsValid(subMeshComponent) || subMeshComponent == this.MeshComp || subMeshComponent.SkeletalMesh == null || !UKismetSystemLibrary.IsValid(subMeshComponent.SkeletalMesh))
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Decoration;
						ELogAuthor author4 = ELogAuthor.CWZ;
						string message4 = "[Decoration] SetMasterFollow 失败: master 无效或缺少 SkeletalMesh";
						<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray6<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", this.Owner.Entity.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Id", newId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("SubMeshName", modelConfig.SubMeshName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("MasterValid", subMeshComponent != null && UKismetSystemLibrary.IsValid(subMeshComponent));
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("MasterSkeletalMeshValid", subMeshComponent != null && UKismetSystemLibrary.IsValid(subMeshComponent.SkeletalMesh));
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 5) = new ValueTuple<string, object>("SameAsSelf", subMeshComponent == this.MeshComp);
						instance5.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 6));
						this.MeshComp.SetMasterPoseComponent(null, false);
						this.SpawnEffects(newId, modelConfig, flag);
						this.ApplyPresentationVisibility("SetDecorationId.SetMasterFollow.Fallback", flag);
						return;
					}
					this.MeshComp.SetMasterPoseComponent(subMeshComponent, true);
					this.MeshComp.SetComponentTickEnabled(true);
					this.MeshComp.K2_AttachToComponent(subMeshComponent, FNameUtil.NONE, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
					this.SpawnEffects(newId, modelConfig, flag);
					this.ApplyPresentationVisibility("SetDecorationId.SetMasterFollow", flag);
					return;
				}
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x0603088A RID: 198794 RVA: 0x00BEAF6C File Offset: 0x00BE916C
		private void DisableSkeletalMesh()
		{
			if (this.MeshComp == null)
			{
				return;
			}
			this.DestroyEffects();
			this.SetVisible(false, "DisableSkeletalMesh");
			this.RemoveTagsListenerInMap(this.DisplayTags);
			this.RemoveTagsListenerInMap(this.HideTags);
			this.ResetMeshAnimationState();
			USkeletalMeshComponent meshComp = this.MeshComp;
			if (meshComp != null)
			{
				meshComp.SetSkeletalMesh(null, true);
			}
			UeSkeletalTickManageComponent ueSkelTickMgrComp = this.UeSkelTickMgrComp;
			if (ueSkelTickMgrComp != null)
			{
				ueSkelTickMgrComp.AddOrRefreshSkeletalMeshComponent(this.MeshComp);
			}
			UeSkeletalTickManageComponent ueSkelTickMgrComp2 = this.UeSkelTickMgrComp;
			if (ueSkelTickMgrComp2 == null)
			{
				return;
			}
			ueSkelTickMgrComp2.EnableOrDisableSkelTick(this.MeshComp, false);
		}

		// Token: 0x0603088B RID: 198795 RVA: 0x00BEAFF4 File Offset: 0x00BE91F4
		private bool CheckHasTagInMap(Dictionary<int, bool> map, bool zero)
		{
			if (map.Count == 0)
			{
				return zero;
			}
			foreach (KeyValuePair<int, bool> keyValuePair in map)
			{
				if (keyValuePair.Value)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603088C RID: 198796 RVA: 0x00BEB058 File Offset: 0x00BE9258
		private bool CheckHasTag()
		{
			return this.CheckHasTagInMap(this.DisplayTags, true) && !this.CheckHasTagInMap(this.HideTags, false);
		}

		// Token: 0x0603088D RID: 198797 RVA: 0x00BEB07C File Offset: 0x00BE927C
		private void AddTagsListenerInMap(Dictionary<int, bool> map, int id, TArray<FGameplayTag> gameplayTags)
		{
			if (this.TagComp == null)
			{
				return;
			}
			this.RemoveTagsListenerInMap(map);
			for (int i = 0; i < gameplayTags.Num(); i++)
			{
				FGameplayTag tag = gameplayTags.Get(i);
				if (tag.TagId() != 0 && !map.ContainsKey(tag.TagId()))
				{
					map[tag.TagId()] = this.TagComp.HasTag(tag.TagId());
					this.TagComp.ListenForTagAddOrRemove(new int?(tag.TagId()), new BaseTagComponent.TTagSwitchedCallback(this.SetDecorationDisplay), null);
				}
			}
		}

		// Token: 0x0603088E RID: 198798 RVA: 0x00BEB10C File Offset: 0x00BE930C
		private void RemoveTagsListenerInMap(Dictionary<int, bool> map)
		{
			foreach (KeyValuePair<int, bool> keyValuePair in map)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.RemoveTagAddOrRemoveListener(keyValuePair.Key, new BaseTagComponent.TTagSwitchedCallback(this.SetDecorationDisplay));
				}
			}
			map.Clear();
		}

		// Token: 0x0603088F RID: 198799 RVA: 0x00BEB180 File Offset: 0x00BE9380
		private void DestroyEffects()
		{
			if (this.SpawnEffectHandleList == null)
			{
				return;
			}
			foreach (int handle in this.SpawnEffectHandleList)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(handle, "[Decoration] SpawnEffects", true, null);
			}
			this.SpawnEffectHandleList = null;
		}

		// Token: 0x06030890 RID: 198800 RVA: 0x00BEB1F8 File Offset: 0x00BE93F8
		private void DisplayEffects(bool display)
		{
			if (this.SpawnEffectHandleList == null)
			{
				return;
			}
			foreach (int handle in this.SpawnEffectHandleList)
			{
				Singleton<EffectSystem>.Instance.SetEffectHidden(handle, !display, "[Decoration] SetVisible", false);
			}
		}

		// Token: 0x06030891 RID: 198801 RVA: 0x00BEB264 File Offset: 0x00BE9464
		private void SpawnEffects(int id, SDecorationConfig modelConfig, bool visible)
		{
			if (modelConfig.Effects.Num() <= 0)
			{
				return;
			}
			for (int i = 0; i < modelConfig.Effects.Num(); i++)
			{
				SDecorationConfig_Effect sdecorationConfig_Effect = modelConfig.Effects.Get(i);
				string text = sdecorationConfig_Effect.EffectData.ToAssetPathName();
				if (!string.IsNullOrEmpty(text))
				{
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject world = GlobalData.World;
					FTransform effectTrans = sdecorationConfig_Effect.EffectTrans;
					FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref effectTrans));
					int num = instance.SpawnEffect(world, ftransformDouble, text, "[Decoration] SpawnEffects", new EffectContext(null, this.MeshComp, false), EEffectType.Scene, null, null, null, false, false);
					if (Singleton<EffectSystem>.Instance.IsValid(num))
					{
						if (this.SpawnEffectHandleList == null)
						{
							this.SpawnEffectHandleList = new List<int>();
						}
						this.SpawnEffectHandleList.Add(num);
						Singleton<EffectSystem>.Instance.GetEffectActor(num).K2_AttachToComponent(this.MeshComp, FNameUtil.GetDynamicFName(sdecorationConfig_Effect.EffectSocketName), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
						if (!visible)
						{
							Singleton<EffectSystem>.Instance.SetEffectHidden(num, true, "[Decoration] SpawnEffectsInitHidden", false);
						}
					}
				}
			}
			this.DisplayEffects(visible);
		}

		// Token: 0x06030892 RID: 198802 RVA: 0x00BEB378 File Offset: 0x00BE9578
		private void SetDecorationDisplay(int tagId, bool tagExist)
		{
			if (this.DisplayTags.ContainsKey(tagId))
			{
				this.DisplayTags[tagId] = tagExist;
			}
			if (this.HideTags.ContainsKey(tagId))
			{
				this.HideTags[tagId] = tagExist;
			}
			this.RefreshVisibility("TagChangeExist", false);
		}

		// Token: 0x06030893 RID: 198803 RVA: 0x00BEB3C7 File Offset: 0x00BE95C7
		public void SetVisible(bool visible, string reason)
		{
			this.RequireVisible = visible;
			if (visible)
			{
				this.RefreshVisibility(reason, false);
				return;
			}
			this.ApplyPresentationVisibility(reason, false);
		}

		// Token: 0x06030894 RID: 198804 RVA: 0x00BEB3E4 File Offset: 0x00BE95E4
		private bool ComputeFinalVisible()
		{
			return this.RequireVisible && this.CheckHasTag() && this.IsActive();
		}

		// Token: 0x06030895 RID: 198805 RVA: 0x00BEB400 File Offset: 0x00BE9600
		public void RefreshVisibility(string reason, bool force = false)
		{
			bool flag = this.CheckHasTag();
			bool flag2 = this.IsActive();
			bool flag3 = this.RequireVisible && flag && flag2;
			if (this.Visible == flag3 && !force)
			{
				return;
			}
			this.ApplyPresentationVisibility(reason, flag3);
		}

		// Token: 0x06030896 RID: 198806 RVA: 0x00BEB43C File Offset: 0x00BE963C
		private void ApplyPresentationVisibility(string reason, bool visible)
		{
			this.Visible = visible;
			USkeletalMeshComponent meshComp = this.MeshComp;
			UKuroAnimLibrary.EndAnimNotifyStates((meshComp != null) ? meshComp.GetAnimInstance() : null);
			if (this.AlwaysUpdate)
			{
				USkeletalMeshComponent meshComp2 = this.MeshComp;
				if (meshComp2 != null)
				{
					meshComp2.SetVisibility(this.Visible, false);
				}
			}
			else
			{
				USkeletalMeshComponent meshComp3 = this.MeshComp;
				if (((meshComp3 != null) ? meshComp3.SkeletalMesh : null) != null)
				{
					UeSkeletalTickManageComponent ueSkelTickMgrComp = this.UeSkelTickMgrComp;
					if (ueSkelTickMgrComp != null)
					{
						ueSkelTickMgrComp.AddOrRefreshSkeletalMeshComponent(this.MeshComp);
					}
					UeSkeletalTickManageComponent ueSkelTickMgrComp2 = this.UeSkelTickMgrComp;
					if (ueSkelTickMgrComp2 != null)
					{
						ueSkelTickMgrComp2.EnableOrDisableSkelTick(this.MeshComp, this.Visible);
					}
				}
				if (this.NeedDelayShow && this.Visible)
				{
					TimerSystem.Instance.Next(delegate(float _)
					{
						USkeletalMeshComponent meshComp5 = this.MeshComp;
						if (meshComp5 == null)
						{
							return;
						}
						meshComp5.SetVisibility(this.Visible, false);
					}, null, null);
				}
				else
				{
					USkeletalMeshComponent meshComp4 = this.MeshComp;
					if (meshComp4 != null)
					{
						meshComp4.SetVisibility(this.Visible, false);
					}
				}
			}
			this.DisplayEffects(this.Visible);
		}

		// Token: 0x06030897 RID: 198807 RVA: 0x00BEB526 File Offset: 0x00BE9726
		private bool IsActive()
		{
			return this.ParentMesh != null && this.Owner.Active && this.Owner.Entity.Active;
		}

		// Token: 0x06030898 RID: 198808 RVA: 0x00BEB554 File Offset: 0x00BE9754
		[return: Nullable(2)]
		private USkeletalMeshComponent GetSubMeshComponent(string mesh)
		{
			if (this.ParentMesh == null || !UKismetSystemLibrary.IsValid(this.ParentMesh))
			{
				return null;
			}
			if (this.ParentMesh.GetOwner() == null || mesh.Length == 0)
			{
				return this.ParentMesh;
			}
			TArray<USceneComponent> tarray = new TArray<USceneComponent>();
			this.ParentMesh.GetChildrenComponents(true, ref tarray);
			TArray<USceneComponent> tarray2 = tarray;
			int num = tarray2.Num();
			for (int i = 0; i < num; i++)
			{
				USceneComponent usceneComponent = tarray2.Get(i);
				string name = usceneComponent.GetName();
				USkeletalMeshComponent uskeletalMeshComponent = usceneComponent as USkeletalMeshComponent;
				if (uskeletalMeshComponent != null && name == mesh)
				{
					return uskeletalMeshComponent;
				}
			}
			return this.ParentMesh;
		}

		// Token: 0x06030899 RID: 198809 RVA: 0x00BEB5EC File Offset: 0x00BE97EC
		public void Clear()
		{
			int currentConfigId = this.CurrentConfigId;
			this.DestroyEffects();
			this.RemoveTagsListenerInMap(this.DisplayTags);
			this.RemoveTagsListenerInMap(this.HideTags);
			this.ResetMeshAnimationState();
			USkeletalMeshComponent meshComp = this.MeshComp;
			if (meshComp != null)
			{
				meshComp.SetSkeletalMesh(null, true);
			}
			this.CurrentConfigId = 0;
			this.Visible = false;
			this.RequireVisible = false;
		}

		// Token: 0x0401BE46 RID: 114246
		[StaticVariableRuleIgnore]
		private static Transform tmpTrans = Transform.Create();

		// Token: 0x0401BE47 RID: 114247
		[Nullable(2)]
		private UeSkeletalTickManageComponent UeSkelTickMgrComp;

		// Token: 0x0401BE48 RID: 114248
		[Nullable(2)]
		public USkeletalMeshComponent MeshComp;

		// Token: 0x0401BE49 RID: 114249
		private int CurrentConfigId;

		// Token: 0x0401BE4A RID: 114250
		private bool Visible = true;

		// Token: 0x0401BE4B RID: 114251
		private bool RequireVisible = true;

		// Token: 0x0401BE4C RID: 114252
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401BE4D RID: 114253
		public Dictionary<int, bool> DisplayTags = new Dictionary<int, bool>();

		// Token: 0x0401BE4E RID: 114254
		public Dictionary<int, bool> HideTags = new Dictionary<int, bool>();

		// Token: 0x0401BE54 RID: 114260
		[Nullable(2)]
		private List<int> SpawnEffectHandleList;
	}
}
