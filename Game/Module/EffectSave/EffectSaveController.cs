using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.Module.EffectSave
{
	// Token: 0x02005D8F RID: 23951
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class EffectSaveController : ControllerBase<EffectSaveController>
	{
		// Token: 0x0603C4E9 RID: 247017 RVA: 0x00F4DCD0 File Offset: 0x00F4BED0
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<DecalAddNotify>(ENotifyMessageId.DecalAddNotify, new Action<DecalAddNotify, Net.CallbackStatus>(this.EffectAddNotify));
			Singleton<Net>.Instance.Register<DecalRemoveNotify>(ENotifyMessageId.DecalRemoveNotify, new Action<DecalRemoveNotify, Net.CallbackStatus>(this.EffectRemoveNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OnEnterOnlineWorld, new Action(this.RemoveEffectOnOnlineModeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.RemoveEffectOnOnlineModeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveInstanceDungeon));
			return true;
		}

		// Token: 0x0603C4EA RID: 247018 RVA: 0x00F4DD6C File Offset: 0x00F4BF6C
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DecalAddNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DecalRemoveNotify);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOnlineWorld, new Action(this.RemoveEffectOnOnlineModeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.RemoveEffectOnOnlineModeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveInstanceDungeon));
			this.RemoveAllEffect("[EffectSaveController] Remove By Controller Clear");
			return true;
		}

		// Token: 0x0603C4EB RID: 247019 RVA: 0x00F4DDFC File Offset: 0x00F4BFFC
		public unsafe void MarkEffectSave(string effectPath, IVector effectLocation, IRotator effectRotation)
		{
			EffectSave? config = ConfigEffectSaveByEffectPath.GetConfig(effectPath, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[EffectSaveController] 特效路径在t.特效保留.xlsx中未配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("effectPath", effectPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			AddDecalRequest addDecalRequest = AddDecalRequest.Create();
			addDecalRequest.SceneId = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id;
			addDecalRequest.Position = new Aki.Protocol.Vector
			{
				X = (float)effectLocation.X,
				Y = (float)effectLocation.Y,
				Z = (float)effectLocation.Z
			};
			addDecalRequest.EffectId = config.Value.EffectId;
			addDecalRequest.Rotation = new Aki.Protocol.Vector
			{
				X = effectRotation.Pitch,
				Y = effectRotation.Roll,
				Z = effectRotation.Yaw
			};
			Singleton<Net>.Instance.Call<AddDecalResponse>(ERequestMessageId.AddDecalRequest, addDecalRequest, delegate(AddDecalResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrCode > Aki.Protocol.ErrorCode.Success)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.LevelPlay;
					ELogAuthor author2 = ELogAuthor.FJH;
					string message2 = "[EffectSaveController] 转发特效信息至服务器失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("effectPath", effectPath);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("errorCode", (response != null) ? new Aki.Protocol.ErrorCode?(response.ErrCode) : null);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}, 0);
		}

		// Token: 0x0603C4EC RID: 247020 RVA: 0x00F4DF18 File Offset: 0x00F4C118
		public void EffectAddNotify(DecalAddNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			int id = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id;
			foreach (DecalInfo decalInfo in data.Info)
			{
				if (decalInfo.Position != null && decalInfo.Rotation != null && decalInfo.SceneId == id)
				{
					EffectSave? config = ConfigEffectSaveByEffectId.GetConfig(decalInfo.EffectId, true);
					if (config == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.LevelPlay;
						ELogAuthor author = ELogAuthor.FJH;
						string message = "[EffectSaveController] 特效Id在t.特效保留.xlsx中未配置";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("effectId", decalInfo.EffectId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						ModelBase<EffectSaveModel>.Instance.TempPosition.X = (double)decalInfo.Position.X;
						ModelBase<EffectSaveModel>.Instance.TempPosition.Y = (double)decalInfo.Position.Y;
						ModelBase<EffectSaveModel>.Instance.TempPosition.Z = (double)decalInfo.Position.Z;
						ModelBase<EffectSaveModel>.Instance.TempRotation.Pitch = decalInfo.Rotation.X;
						ModelBase<EffectSaveModel>.Instance.TempRotation.Roll = decalInfo.Rotation.Y;
						ModelBase<EffectSaveModel>.Instance.TempRotation.Yaw = decalInfo.Rotation.Z;
						ModelBase<EffectSaveModel>.Instance.TempTransform.SetLocation(ModelBase<EffectSaveModel>.Instance.TempPosition);
						EffectSaveModel instance2 = ModelBase<EffectSaveModel>.Instance;
						FQuat fquat = ModelBase<EffectSaveModel>.Instance.TempRotation.Quaternion();
						instance2.TempTransform.SetRotation(fquat);
						EffectSystem instance3 = Singleton<EffectSystem>.Instance;
						UObject world = GlobalData.World;
						FTransformDouble? ftransformDouble = new FTransformDouble?(ModelBase<EffectSaveModel>.Instance.TempTransform);
						int value = instance3.SpawnEffect(world, ftransformDouble, config.Value.EffectPath, "[EffectSaveController] Add By Proto_DecalAddNotify", null, EEffectType.Scene, null, null, null, false, false);
						ModelBase<EffectSaveModel>.Instance.EffectSaveMap[Singleton<MathUtils>.Instance.LongToBigInt(decalInfo.DecalId)] = value;
					}
				}
			}
		}

		// Token: 0x0603C4ED RID: 247021 RVA: 0x00F4E148 File Offset: 0x00F4C348
		public void EffectRemoveNotify(DecalRemoveNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (DecalInfo decalInfo in data.Info)
			{
				long key = Singleton<MathUtils>.Instance.LongToBigInt(decalInfo.DecalId);
				int num;
				ModelBase<EffectSaveModel>.Instance.EffectSaveMap.TryGetValue(key, out num);
				if (num != 0)
				{
					if (Singleton<EffectSystem>.Instance.IsValid(num))
					{
						Singleton<EffectSystem>.Instance.StopEffectById(num, "[EffectSaveController] Remove By Proto_DecalRemoveNotify", true, null);
					}
					ModelBase<EffectSaveModel>.Instance.EffectSaveMap.Remove(key);
				}
			}
		}

		// Token: 0x0603C4EE RID: 247022 RVA: 0x00F4E1F0 File Offset: 0x00F4C3F0
		public void RemoveEffectOnOnlineModeChange()
		{
			this.RemoveAllEffect("[EffectSaveController] Remove By Online Mode Change");
		}

		// Token: 0x0603C4EF RID: 247023 RVA: 0x00F4E1FD File Offset: 0x00F4C3FD
		public void OnLeaveInstanceDungeon()
		{
			this.RemoveAllEffect("[EffectSaveController] Remove By Leave Instance Dungeon");
		}

		// Token: 0x0603C4F0 RID: 247024 RVA: 0x00F4E20C File Offset: 0x00F4C40C
		private void RemoveAllEffect(string reason)
		{
			foreach (int num in ModelBase<EffectSaveModel>.Instance.EffectSaveMap.Values)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(num))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(num, reason, true, null);
				}
			}
			ModelBase<EffectSaveModel>.Instance.EffectSaveMap.Clear();
		}
	}
}
