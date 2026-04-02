using HutongGames.PlayMaker.Actions;
using Modding;
using System.Collections.Generic;
using UnityEngine;
using Vasi;
namespace UumuuHack
{
	public class UumuuHack:Mod,IMenuMod
	{
		public bool ToggleButtonInsideMenu=>true;
		public bool on;
		public override string GetVersion()=>VersionUtil.GetVersion<UumuuHack>();
		public override void Initialize()
		{
			On.PlayMakerFSM.OnEnable+=OnEnable;
		}
		public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)=>
			new List<IMenuMod.MenuEntry>
			{
				new IMenuMod.MenuEntry
				{
					Name="Uumuu Hack",
					Description="This uumuu ... seems weird ...",
					Values=new string[]{"Off","On"},
					Saver=o=>this.on=o!=0,
					Loader=()=>this.on?1:0
				}
			};
		private void OnEnable(On.PlayMakerFSM.orig_OnEnable orig,PlayMakerFSM self)
		{
			switch(self.FsmName)
			{
				case"Mega Jellyfish"when self.name=="Mega Jellyfish":
					if(this.on)
					{
						self.GetAction<RandomFloat>("Set Timer",1).max=2f;
						self.GetAction<WaitRandom>("Idle",1).timeMin=2f;
					}
					break;
			}
			orig(self);
		}
	}
}