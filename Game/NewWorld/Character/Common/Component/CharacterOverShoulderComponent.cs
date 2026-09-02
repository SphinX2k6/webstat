using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490B RID: 18699
	[NullableContext(2)]
	[Nullable(0)]
	public class CharacterOverShoulderComponent : EntityComponent
	{
		// Token: 0x1700834B RID: 33611
		// (get) Token: 0x06030DE5 RID: 200165 RVA: 0x00C1B502 File Offset: 0x00C19702
		[Nullable(1)]
		public new static Type[] Dependencies
		{
			[NullableContext(1)]
			get
			{
				return new Type[]
				{
					typeof(CharacterActorComponent),
					typeof(CharacterInputComponent),
					typeof(BaseTagComponent)
				};
			}
		}

		// Token: 0x06030DE6 RID: 200166 RVA: 0x00C1B534 File Offset: 0x00C19734
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
			this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.GaitComp = base.Entity.GetComponent<RoleGaitComponent>();
			this.AddChangeOverShoulderModeListener();
			return true;
		}

		// Token: 0x06030DE7 RID: 200167 RVA: 0x00C1B59D File Offset: 0x00C1979D
		protected override bool OnEnd()
		{
			this.RemoveChangeOverShoulderModeListener();
			return true;
		}

		// Token: 0x06030DE8 RID: 200168 RVA: 0x00C1B5A6 File Offset: 0x00C197A6
		private void AddChangeOverShoulderModeListener()
		{
			BaseTagComponent tagComp = this.TagComp;
			this.ChangeOverShoulderMode = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.越肩模式"]), delegate(int tagId, bool tagExists)
			{
				if (tagExists)
				{
					this.TryLoadAndInitFromOverShoulderConfigAsset();
					return;
				}
				this.ClearOverShoulderModeState();
			}, null) : null);
		}

		// Token: 0x06030DE9 RID: 200169 RVA: 0x00C1B5E1 File Offset: 0x00C197E1
		private void RemoveChangeOverShoulderModeListener()
		{
			this.ClearOverShoulderModeState();
			OverShoulderModeConfig overShoulderConfig = this.OverShoulderConfig;
			if (overShoulderConfig != null)
			{
				overShoulderConfig.TryAddOrRemoveTags(base.Entity, false);
			}
			this.OverShoulderConfig = null;
			ITagTask changeOverShoulderMode = this.ChangeOverShoulderMode;
			if (changeOverShoulderMode != null)
			{
				changeOverShoulderMode.EndTask();
			}
			this.ChangeOverShoulderMode = null;
		}

		// Token: 0x06030DEA RID: 200170 RVA: 0x00C1B620 File Offset: 0x00C19820
		private void CreateOverShoulderInputLayer()
		{
			if (this.OverShoulderModeInputLayer != null)
			{
				this.RemoveOverShoulderInputLayer();
			}
			this.OverShoulderModeInputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.OverShoulder) as OverShoulderInputLayer);
			this.OverShoulderModeInputLayer.Init(base.Entity);
			ControllerBase<InputController>.Instance.AddInputLayer(base.Entity.Id, this.OverShoulderModeInputLayer);
		}

		// Token: 0x06030DEB RID: 200171 RVA: 0x00C1B67E File Offset: 0x00C1987E
		private void RemoveOverShoulderInputLayer()
		{
			if (this.OverShoulderModeInputLayer != null)
			{
				ControllerBase<InputController>.Instance.RemoveInputLayer(this.OverShoulderModeInputLayer);
				this.OverShoulderModeInputLayer.Clear();
				this.OverShoulderModeInputLayer = null;
			}
		}

		// Token: 0x06030DEC RID: 200172 RVA: 0x00C1B6AA File Offset: 0x00C198AA
		private void TryLoadAndInitFromOverShoulderConfigAsset()
		{
			Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_OverShoulderModeConfig_C", delegate
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<BP_OverShoulderModeConfig_C>("/Game/Aki/Character/Role/Common/Data/DA/DA_OverShoulderModeConfig.DA_OverShoulderModeConfig", delegate([Nullable(2)] BP_OverShoulderModeConfig_C asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						return;
					}
					OverShoulderModeConfig overShoulderModeConfig = new OverShoulderModeConfig();
					overShoulderModeConfig.InitFromAsset(asset);
					if (!overShoulderModeConfig.IsValid())
					{
						return;
					}
					this.OverShoulderConfig = overShoulderModeConfig;
					this.InitOverShoulderModeState();
				}, 100, "js_undefined");
			}, "js_undefined");
		}

		// Token: 0x06030DED RID: 200173 RVA: 0x00C1B6CC File Offset: 0x00C198CC
		private void InitOverShoulderModeState()
		{
			if (this.IsOverShoulderMode)
			{
				return;
			}
			this.IsOverShoulderMode = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[OverShoulderMode] 进入越肩模式";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			OverShoulderModeConfig overShoulderConfig = this.OverShoulderConfig;
			if (overShoulderConfig != null)
			{
				overShoulderConfig.TryAddOrRemoveTags(base.Entity, true);
			}
			this.CreateOverShoulderInputLayer();
			CharacterInputComponent inputComp = this.InputComp;
			if (inputComp != null)
			{
				inputComp.EnableOverShoulderMode(this.OverShoulderConfig);
			}
			RoleGaitComponent gaitComp = this.GaitComp;
			if (gaitComp == null)
			{
				return;
			}
			gaitComp.EnableSprintStop(false);
		}

		// Token: 0x06030DEE RID: 200174 RVA: 0x00C1B768 File Offset: 0x00C19968
		private void ClearOverShoulderModeState()
		{
			if (!this.IsOverShoulderMode)
			{
				return;
			}
			this.IsOverShoulderMode = false;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[OverShoulderMode] 退出越肩模式";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			OverShoulderModeConfig overShoulderConfig = this.OverShoulderConfig;
			if (overShoulderConfig != null)
			{
				overShoulderConfig.TryAddOrRemoveTags(base.Entity, false);
			}
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp != null)
			{
				stateComp.SetDirectionState(ECharDirectionState.FaceDirection);
			}
			Entity entity = base.Entity;
			if (entity != null)
			{
				BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
				if (component != null)
				{
					component.SetLockedRotation(false);
				}
			}
			this.RemoveOverShoulderInputLayer();
			CharacterInputComponent inputComp = this.InputComp;
			if (inputComp != null)
			{
				inputComp.EnableOverShoulderMode(null);
			}
			RoleGaitComponent gaitComp = this.GaitComp;
			if (gaitComp == null)
			{
				return;
			}
			gaitComp.EnableSprintStop(true);
		}

		// Token: 0x06030DEF RID: 200175 RVA: 0x00C1B82C File Offset: 0x00C19A2C
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterOverShoulderComponent characterOverShoulderComponent = (CharacterOverShoulderComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterOverShoulderComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InputComp"))
			{
				if (characterOverShoulderComponent.InputComp == null)
				{
					this.InputComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (characterOverShoulderComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (characterOverShoulderComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("GaitComp"))
			{
				if (characterOverShoulderComponent.GaitComp == null)
				{
					this.GaitComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleGaitComponent>(this.GaitComp), "GaitComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsOverShoulderMode"))
			{
				this.IsOverShoulderMode = characterOverShoulderComponent.IsOverShoulderMode;
			}
			if (base.CanResetComponentProperty("OverShoulderModeInputLayer"))
			{
				if (characterOverShoulderComponent.OverShoulderModeInputLayer == null)
				{
					this.OverShoulderModeInputLayer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<OverShoulderInputLayer>(this.OverShoulderModeInputLayer), "OverShoulderModeInputLayer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OverShoulderConfig"))
			{
				if (characterOverShoulderComponent.OverShoulderConfig == null)
				{
					this.OverShoulderConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<OverShoulderModeConfig>(this.OverShoulderConfig), "OverShoulderConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ChangeOverShoulderMode"))
			{
				if (characterOverShoulderComponent.ChangeOverShoulderMode == null)
				{
					this.ChangeOverShoulderMode = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.ChangeOverShoulderMode), "ChangeOverShoulderMode"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C171 RID: 115057
		[Nullable(1)]
		private const string OVER_SHOULDER_CONFIG_PATH = "/Game/Aki/Character/Role/Common/Data/DA/DA_OverShoulderModeConfig.DA_OverShoulderModeConfig";

		// Token: 0x0401C172 RID: 115058
		public CharacterActorComponent ActorComp;

		// Token: 0x0401C173 RID: 115059
		public CharacterInputComponent InputComp;

		// Token: 0x0401C174 RID: 115060
		public CharacterUnifiedStateComponent StateComp;

		// Token: 0x0401C175 RID: 115061
		public BaseTagComponent TagComp;

		// Token: 0x0401C176 RID: 115062
		public RoleGaitComponent GaitComp;

		// Token: 0x0401C177 RID: 115063
		private bool IsOverShoulderMode;

		// Token: 0x0401C178 RID: 115064
		private OverShoulderInputLayer OverShoulderModeInputLayer;

		// Token: 0x0401C179 RID: 115065
		private OverShoulderModeConfig OverShoulderConfig;

		// Token: 0x0401C17A RID: 115066
		private ITagTask ChangeOverShoulderMode;
	}
}
